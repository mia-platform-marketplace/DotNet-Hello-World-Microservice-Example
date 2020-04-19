/*
 * Copyright 2020 Mia srl
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

// PLEASE NOTE: You don't need to modify this code. Just add a new Controller in Controllers folder
namespace HelloWorld
{
    public class Startup
    {

        // The name of entry point form Mia-Platform API Portal
        private const string DOCUMENTATION_MIA = "documentation";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Enable swagger
            services.AddSwaggerGen(c =>
            {
                //
                c.SwaggerDoc(DOCUMENTATION_MIA, new OpenApiInfo { Title = "Hello API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable debug page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable OpenAPI Specification for Mia-Platform API Portal
             app.UseSwagger(c =>
            {
                c.RouteTemplate = "/{documentName}/json";
            });

            // Register routes
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}