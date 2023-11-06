---
modificationDate: "10/16/2023"
_title: The ContentTypeReader class | MonoGame Content Pipeline Extension Tutorial Series
_slug: tutorials/content-pipeline-extension/11_the-content-reader
_description: Let's take a look at the ContentTypeReader class.
---

# The `ContentTypeReader`
The job of the `ContentTypeReader` is to read the contents of an `.xnb` file and return back the expected type instantiated from the data that is read.

## The Anatomy of a `ContentTypeReader`
On the previous page, we had to manually create the `JsonContentTypeReader` class and add it to our project.  The code that was given for it is just a base template that can be used to get one started.  Below you can find the code again.


```cs
using Microsoft.Xna.Framework.Content;
using System;

namespace JsonContentPipeline
{
    public class JsonContentTypeReader<T> : ContentTypeReader<T>
    {
        protected override T Read(ContentReader input, T existingInstance)
        {
            return default(T);
        }
    }
}
```

This is the basic foundation of a `ContentTypeReader`.  So let's break it down into specific parts, discuss what they are, and why they matter.

### The `ContentTypeReader` Declaration
First is the declaration of the class itself

```cs
public class JsonContentTypeReader : ContentTypeReader<T>
```

From this we can see that we are inheriting from the `ContentTypeReader<T>` class.  This based class comes from the `Microsoft.Xna.Framework.Content` namespace.  It requires one generic `T` type that specifies the type this reader is expected to return back.

### The `Read(ContentReader, T)` Method
This is the method that is responsible for the actual reading of the `.xnb` file adn using the data read to construct the type instance that we are expected to return back.  The method has two parameters.

The first parameter is the `ContentReader reader` parameter. This supplies us with an instance of the `ContentReader` class, which is just a derived class from `BinaryReader` that contains some additional overloads to read MonoGame specific types as well.

The second parameter is the `T existingInstance` parameter.  This will contain an existing instance of the content that is being loaded if it was loaded previously before.  The `ContentManager` caches the content that is loaded, so we can check here if there is already an existing instance and just return that back if we want instead of rereading the entire `.xnb` file again.


## Next Steps
On the next page, we'll edit the `JsonContentTypeReader` class that we created and went over so that it performs all the logic necessary to read the content of hte `.xnb` file and return the expected result.
