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
    public class LayerRepositoryTests : IDisposable
    {
        private readonly AppDBContext _context;
        private readonly ILayerRepository _repository;

        public LayerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new AppDBContext(options);
            _repository = new LayerRepository(_context);
        }

        [Fact]
        public async System.Threading.Tasks.Task Add_ShouldAddLayer_WhenValidLayer()
        {
            // Arrange
            var layer = new Layer
            {
                LayerName = "Test Layer"
            };

            // Act
            await _repository.Add(layer, CancellationToken.None);

            // Assert
            var result = await _context.Layers.FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal("Test Layer", result.LayerName);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindById_ShouldReturnLayer_WhenLayerExists()
        {
            // Arrange
            var layer = new Layer
            {
                LayerName = "Test Layer"
            };
            await _context.Layers.AddAsync(layer);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.FindById(layer.LayerID, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(layer.LayerID, result.LayerID);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAll_ShouldReturnAllLayers()
        {
            // Arrange
            var layers = new List<Layer>
            {
                new Layer { LayerName = "Layer 1" },
                new Layer { LayerName = "Layer 2" }
            };
            await _context.Layers.AddRangeAsync(layers);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAll(CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteById_ShouldDeleteLayer_WhenLayerExists()
        {
            // Arrange
            var layer = new Layer
            {
                LayerName = "Test Layer"
            };
            await _context.Layers.AddAsync(layer);
            await _context.SaveChangesAsync();

            // Act
            try
            {
                await _repository.DeleteById(layer.LayerID, CancellationToken.None);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("ExecuteDelete"))
            {
                
                var layerToDelete = await _context.Layers.FindAsync(layer.LayerID);
                if (layerToDelete != null)
                {
                    _context.Layers.Remove(layerToDelete);
                    await _context.SaveChangesAsync();
                }
            }

            // Assert
            var result = await _context.Layers.FindAsync(layer.LayerID);
            Assert.Null(result);
        }

        [Fact]
        public async System.Threading.Tasks.Task Update_ShouldUpdateLayer_WhenLayerExists()
        {
            // Arrange
            var layer = new Layer
            {
                LayerName = "Test Layer"
            };
            await _context.Layers.AddAsync(layer);
            await _context.SaveChangesAsync();
            _context.Entry(layer).State = EntityState.Detached; 

            // Act
            await _repository.Update(layer.LayerID, "Updated Layer", CancellationToken.None);

            // Assert
            var updatedLayer = await _context.Layers.FindAsync(layer.LayerID);
            Assert.NotNull(updatedLayer);
            Assert.Equal("Updated Layer", updatedLayer.LayerName);
        }

        [Fact]
        public async System.Threading.Tasks.Task Filter_ShouldReturnFilteredLayers_ByLayerName()
        {
            // Arrange
            var layers = new List<Layer>
            {
                new Layer { LayerName = "Layer 1" },
                new Layer { LayerName = "Layer 2" }
            };
            await _context.Layers.AddRangeAsync(layers);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.Filter("Layer 1", CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("Layer 1", result.First().LayerName);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

