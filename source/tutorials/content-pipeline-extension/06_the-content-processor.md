---
modificationDate: "10/16/2023"
_title: The ContentProcessor class | MonoGame Content Pipeline Extension Tutorial Series
_description: Let's take a look at the ContentProcessor class.
---

# The `ContentProcessor`
The job of the `ContentProcessor` is to process the content that was imported by the `ContentImporter` and transform it in anyway necessary before sending it to the `ContentWriter` to be written to an `.xnb` file.

## The Anatomy of a `ContentProcessor`
Let's take a look at the anatomy of a `ContentProcessor` by taking a look at the `JsonContentProcessor` class.  If you open this file, you will see the following:

```cs
using Microsoft.Xna.Framework.Content.Pipeline;

using TInput = System.String;
using TOutput = System.String;

namespace JsonContentPipelineExtension
{
    [ContentProcessor(DisplayName = "Processor1")]
    internal class JsonContentProcessor : ContentProcessor<TInput, TOutput>
    {
        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            return default(TOutput);
        }
    }
}
```

So let's break this down into specific parts, discuss what they are, and why they matter.

### Using Aliases
The first part we'll look at is the **using aliases**

```cs
using TInput = System.String;
using TOutput = System.String;
```

Just like in the `ContentImporter` the MonoGame template gives us **using aliases** to define the type that is expected to be input into the processor (`TInput`) and the type that is expected to be returned from the processor (`TOutput`) to be sent to the `ContentWriter`.


### The `ContentProcessorAttribute`
The next part we'll look at is the `ContentProcessorAttribute` that decorates the class declaration.

```cs
[ContentProcessor(DisplayName = "Processor1")]
```

This attribute **must** be added to the class that will serve as our content processor.  It only has the `DisplayName` property to set which allows us to set the display name shown for the processor inside the **MGCB Editor**.

### The `ContentProcessor` Declaration
Next, let's take a look at the declaration of the class itself

```cs
internal class JsonContentProcessor : ContentProcessor<TInput, TOutput>
```

From this we can see that we are inheriting from `ContentProcessor<Tin, TOut>`.  This base class comes from the `Microsoft.Xna.Framework.Content.Pipeline` namespace.  It also requires two generic `T` types which specify the type that is sent to this processor from the `ContentImporter` and the type expected to be returned from this processor once it finishes processing.

In our specific case we have specified that the input type to be `TInput`, which is the alias for `System.String` and the output type is `TOutput` which is also an alias for `System.String`.  This means our processor expects a string value as input and is expected to return back a string value when finished.

### The `Process(TInput, ContentProcessorContext)` Method
Inside the class, we are provided with a single method that is overriding from the base class.  This is the `Process(TInput, ContentProcessorContext)` method.

```cs
public override TOutput Process(TInput input, ContentProcessorContext context)
```

This method is where we'll do the actual processing of the data that is sent from the `ContentImporter`.  Once all processing is done, we then return back the expected return type.

This method also contains the `ContentProcessorContext` parameter.  This parameter provides additional context for the processor which allows us to do things like adding additional files as dependencies to be processed.  This is not something we'll be needing in this tutorial, but I can cover the concepts of doing this in a future one.

### Properties
One thing that is not given by the out-of-the-box template is properties for the `ContentProcessor`.  Sometimes you may need for the end user to be able to configure how the processor processes the content.  You can give them these configurations by adding properties to the `ContentProcessor` class file and decorating them with the `DisplayNameAttribute`.  Doing this will show them as configurable properties in the **MGCB Editor** for the end user.

This is something we will do on the next page when we edit the `JsonContentProcessor` to process our JSON content.

## Next Steps
On the next page, we'll edit the `JsonContentProcessor` so that it performs all the logic necessary to process the contents of a JSON file.


