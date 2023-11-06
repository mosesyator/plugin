using System;
using Microsoft.Xrm.Sdk;

namespace Opptyplugin
{
    public class OpptyPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider.
            Microsoft.Xrm.Sdk.IPluginExecutionContext? context = serviceProvider.GetService(typeof(Microsoft.Xrm.Sdk.IPluginExecutionContext)) as Microsoft.Xrm.Sdk.IPluginExecutionContext;

            // Check if the context is not null before using it.
            if (context != null && context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity entity)
            {
                // Obtain the target entity from the input parameters.
                if (entity.LogicalName == "opportunity")
                {
                    if (!entity.Attributes.Contains("description"))
                    {
                        entity.Attributes["description"] = "Here is the new description";
                    }
                    else
                    {
                        throw new InvalidPluginExecutionException("The description can only be set by the system.");
                    }
                }
            }
        }
    }
}
