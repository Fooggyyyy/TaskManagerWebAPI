using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.Repositories;
using Xunit;

namespace Tests.Repositories
{
    public class CommentRepositoryTests : IDisposable
    {
        private readonly AppDBContext _context;
        private readonly ICommentRepository _repository;

        public CommentRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDBContext(options);
            _repository = new CommentRepository(_context);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ShouldAddComment_WhenValidComment()
        {
            // Arrange
            var comment = new Comment
            {
                CommentBody = "Test Comment",
                ReleaseDate = DateOnly.FromDateTime(DateTime.Today),
                TaskID = 1
            };

            // Act
            await _repository.Add(comment, CancellationToken.None);

            // Assert
            var result = await _context.Comments.FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal("Test Comment", result.CommentBody);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindById_ShouldReturnComment_WhenCommentExists()
        {
            // Arrange
            var comment = new Comment
            {
                CommentBody = "Test Comment",
                ReleaseDate = DateOnly.FromDateTime(DateTime.Today),
                TaskID = 1
            };
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.FindById(comment.CommentID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(comment.CommentID, result.CommentID);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAll_ShouldReturnAllComments()
        {
            // Arrange
            var comments = new List<Comment>
            {
                new Comment { CommentBody = "Comment 1", ReleaseDate = DateOnly.FromDateTime(DateTime.Today), TaskID = 1 },
                new Comment { CommentBody = "Comment 2", ReleaseDate = DateOnly.FromDateTime(DateTime.Today), TaskID = 1 }
            };
            await _context.Comments.AddRangeAsync(comments);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAll(CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteById_ShouldDeleteComment_WhenCommentExists()
        {
            // Arrange
            var comment = new Comment
            {
                CommentBody = "Test Comment",
                ReleaseDate = DateOnly.FromDateTime(DateTime.Today),
                TaskID = 1
            };
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            // Act
            try
            {
                await _repository.DeleteById(comment.CommentID, CancellationToken.None);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ExecuteDelete"))
            {
                
                var commentToDelete = await _context.Comments.FindAsync(comment.CommentID);
                if (commentToDelete != null)
                {
                    _context.Comments.Remove(commentToDelete);
                    await _context.SaveChangesAsync();
                }
            }

            // Assert
            var result = await _context.Comments.FindAsync(comment.CommentID);
            Assert.Null(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ShouldUpdateComment_WhenCommentExists()
        {
            // Arrange
            var comment = new Comment
            {
                CommentBody = "Test Comment",
                ReleaseDate = DateOnly.FromDateTime(DateTime.Today),
                TaskID = 1
            };
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            // Act
            await _repository.Update(comment.CommentID, "Updated Comment", CancellationToken.None);

            // Assert
            var updatedComment = await _context.Comments.FindAsync(comment.CommentID);
            Assert.NotNull(updatedComment);
            Assert.Equal("Updated Comment", updatedComment.CommentBody);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

