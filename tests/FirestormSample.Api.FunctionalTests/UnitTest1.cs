using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FirestormSample.Api.FunctionalTests.Helpers;
using FirestormSample.EntityFramework;
using FirestormSample.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FirestormSample.Api.FunctionalTests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly IServiceProvider _services;

        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _services = factory.Server.Host.Services;
        }
        
        [Fact]
        public async Task CreateNewBoard_Returns201()
        {
            var response = await _client.PostAsJsonAsync("/boards", new
            {
                slug = "test-1",
                name = "Test 1"
            });

            var createdUri = response.Headers.Location;
            var content = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(201);
            createdUri.ToString().Should().StartWith("/boards/");
            content.Should().BeNullOrEmpty();
        }
        
        [Fact]
        public async Task CreateNewPost_Returns201()
        {
            using (var serviceScope = _services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<SampleDbContext>();
                
                dbContext.Boards.Add(new Board
                {
                    Slug = "test-2"
                });

                await dbContext.SaveChangesAsync();
            }
            
            var response = await _client.PostAsJsonAsync("/boards/test-2/posts", new
            {
                slug = "this-test-post",
                text = "This is a test post"
            });

            var createdUri = response.Headers.Location;
            var content = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(201);
            createdUri.ToString().Should().StartWith("/boards/test-2/posts/");
            content.Should().BeNullOrEmpty();
        }
        
        [Fact]
        public async Task LikePost_Returns201()
        {
            using (var serviceScope = _services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<SampleDbContext>();

                dbContext.Boards.Add(new Board
                {
                    Slug = "test-3",
                    Posts = new[]
                    {
                        new Post
                        {
                            Slug = "this-new-post",
                            Text = "This is a new post"
                        }
                    }
                });

                await dbContext.SaveChangesAsync();
            }
            
            var r3 = await _client.PostAsJsonAsync("/boards/test-3/posts/this-new-post/likes", new
            {
            });
            
            var response = await _client.GetAsync("/boards/test-3/posts/this-new-post/total_likes");

            var content = await response.Content.ReadAsAsync<int>();

            response.StatusCode.Should().Be(200);
            content.Should().Be(1);
        }
    }
}