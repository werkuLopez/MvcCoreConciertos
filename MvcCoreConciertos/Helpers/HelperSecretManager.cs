﻿using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using Amazon;

namespace MvcCoreConciertos.Helpers
{
    public static class HelperSecretManager
    {


        public static async Task<string> GetSecretAsync()
        {
            string secretName = "secretoconciertos";
            string region = "us-east-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;
            response = await client.GetSecretValueAsync(request);

            string secret = response.SecretString;

            return secret;

            // Your code goes here
        }
    }
}
