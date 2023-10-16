using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using TInput = System.String;
using TOutput = JsonContentPipelineExtension.JsonContentProcessorResult;

namespace JsonContentPipelineExtension
{
    [ContentProcessor(DisplayName = "Json Processor - Aristurtle")]
    internal class JsonContentProcessor : ContentProcessor<TInput, TOutput>
    {
        [DisplayName("Minify JSON")]
        public bool Minify { get; set; } = true;

        [DisplayName("Runtime Type")]
        public string RuntimeType { get; set; } = string.Empty;

        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            if(string.IsNullOrEmpty(RuntimeType))
            {
                throw new Exception("No Runtime Type was specified for this content.");
            }

            if (Minify)
            {
                input = MinifyJson(input);
            }

            JsonContentProcessorResult result = new JsonContentProcessorResult();
            result.Json = input;
            result.RuntimeType = RuntimeType;

            return result;
        }

        private string MinifyJson(string json)
        {
            JsonWriterOptions options = new JsonWriterOptions()
            {
                Indented = false,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            JsonDocument doc = JsonDocument.Parse(json);

            using (MemoryStream stream = new MemoryStream())
            {
                using (Utf8JsonWriter writer = new Utf8JsonWriter(stream, options))
                {
                    doc.WriteTo(writer);
                    writer.Flush();
                }

                return Encoding.UTF8.GetString(stream.ToArray());
            }

        }
    }
}