using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

using TInput = JsonContentPipelineExtension.JsonContentResult;

namespace JsonContentPipelineExtension
{
    [ContentTypeWriter]
    internal class JsonContentTypeWriter : ContentTypeWriter<TInput>
    {
        protected override void Write(ContentWriter output, TInput value)
        {
            output.Write(value.Json);
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "JsonContentPipeline.JsonContentReader, JsonContentPipeline";
        }
    }
}