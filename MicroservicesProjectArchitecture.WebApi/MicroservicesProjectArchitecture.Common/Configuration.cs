using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicesProjectArchitecture.Common
{
    public class Configuration : IConfiguration
    {
        private readonly string displayUserErrorMessage;
        public string DisplayUserErrorMessage { get => displayUserErrorMessage; }

        public Configuration()
        {
            displayUserErrorMessage = "Internal server error";// it can also be read from a configuration file
        }
    }
}
