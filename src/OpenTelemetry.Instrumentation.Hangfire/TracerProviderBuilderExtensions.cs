// <copyright file="TracerProviderBuilderExtensions.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace OpenTelemetry.Trace
{
    using OpenTelemetry.Instrumentation.Hangfire.Implementation;
    using OpenTelemetry.Internal;

    /// <summary>
    /// Extension methods to simplify registering of Hangfire job instrumentation.
    /// </summary>
    public static class TracerProviderBuilderExtensions
    {
        /// <summary>
        /// Adds Hangfire instrumentation to the tracer provider.
        /// </summary>
        /// <param name="builder"><see cref="TracerProviderBuilder"/> being configured.</param>
        /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
        public static TracerProviderBuilder AddHangfireInstrumentation(this TracerProviderBuilder builder)
        {
            Guard.ThrowIfNull(builder);

            Hangfire.GlobalJobFilters.Filters.Add(new HangfireInstrumentationJobFilterAttribute());

            return builder.AddSource(HangfireInstrumentation.ActivitySourceName);
        }
    }
}
