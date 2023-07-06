﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Azure.Core;
using Azure.Identity;
using Newtonsoft.Json;

namespace FhirMigrationTool.Configuration
{
    public class MigrationOptions
    {
        [JsonProperty("sourceFhirUri")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Uri SourceFhirUri { get; set; }

        [JsonProperty("destinationFhirUri")]
        public Uri DestinationFhirUri { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [JsonProperty("stagingStorageAccountName")]
        public string StagingStorageAccountName { get; set; } = string.Empty;

        [JsonProperty("stagingContainerName")]
        public string StagingContainerName { get; set; } = string.Empty;

        [JsonProperty("scheduleInterval")]
        public double ScheduleInterval { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; } = string.Empty;

        [JsonProperty("endDate")]
        public string EndDate { get; set; } = string.Empty;

        [JsonProperty("AppInsightConnectionString")]
        public string AppInsightConnectionstring { get; set; } = string.Empty;

        [JsonProperty("importMode")]
        public string ImportMode { get; set; } = "IncrementalLoad";

        public List<string>? SurfaceCheckResources { get; set; }

        [JsonProperty("DeepCheckCount")]
        public int DeepCheckCount { get; set; }

        [JsonProperty("UserAgent")]
        public string UserAgent { get; set; } = "FhirMigrationTool";

        [JsonProperty("SourceHttpClient")]
        public string SourceHttpClient { get; set; } = "SourceFhirEndpoint";

        [JsonProperty("DestinationHttpClient")]
        public string DestinationHttpClient { get; set; } = "DestinationFhirEndpoint";

        [JsonProperty("TokenCredential")]
        public TokenCredential TokenCredential { get; set; } = new DefaultAzureCredential();

        [JsonProperty("retryCount")]
        public int RetryCount { get; set; }

        [JsonProperty("waitForRetry")]
        public double WaitForRetry { get; set; }

        [JsonProperty("debug")]
        public bool Debug { get; set; }

        public bool ValidateConfig()
        {
            try
            {
                return SourceFhirUri != null
                    && DestinationFhirUri != null
                    && !string.IsNullOrEmpty(ImportMode)
                    && ScheduleInterval > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
