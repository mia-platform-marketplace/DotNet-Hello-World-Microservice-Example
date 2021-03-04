using MiaServiceDotNetLibrary.Environment;

namespace DotNetCore_Hello_World_Microservice_Example
{
    public class EnvsConfigurations: MiaEnvsConfigurations
    {
        public EnvsConfigurations()
        {
            /*
             * Add here your custom environment variables
             * You can use System.ComponentModel.DataAnnotations attributes
             * to validate your environment variables, like this:
             * [Required]
             * [MinLength(10)]
             * public string MyCustomEnv { get; set; }
             * 
             * NB. all your envs must have a public get and set methods
            */
        }

        public override void Validate()
        {
            /*
             * DO NOT remove this line or you will lose the validation of
             * the Mia-Platform Environment variables and the
             * default validation that uses the
             * System.ComponentModel.DataAnnotations library attributes
             * to validate the properties
            */
            base.Validate();

            // Add here your custom validation constraints
        }
    }
}
