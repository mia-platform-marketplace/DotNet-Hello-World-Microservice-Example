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
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Mia.Logging;
using Serilog.Events;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var logLevel = Environment.GetEnvironmentVariable("LOG_LEVEL");
                Log.Logger = GetLoggerConfiguration(logLevel)
                    .WriteTo.Console(new MiaJsonFormatter())
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                    .CreateLogger();
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Error(e, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static LoggerConfiguration GetLoggerConfiguration(string logLevel)
        {
            var logConfig = new LoggerConfiguration();

            switch (logLevel)
            {
                case "ERROR": return logConfig.MinimumLevel.Error();
                case "WARNING": return logConfig.MinimumLevel.Warning();
                case "INFO": return logConfig.MinimumLevel.Information();
                case "DEBUG": return logConfig.MinimumLevel.Debug();
                case "TRACE": return logConfig.MinimumLevel.Verbose();
                default: return logConfig.MinimumLevel.Information();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
