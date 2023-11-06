---
modificationDate: "10/16/2023"
_title: Content Pipeline Workflow | MonoGame Content Pipeline Extension Tutorial Series
_description: What is the content pipeline?
---

# Content Pipeline Workflow

Before we get into creating the extension, it's important to understand what the **Content Pipeline** is.  Many people confuse the term *Content Pipeline* to mean specifically the MGCB Editor, which is not the case.  Instead, the **Content Pipeline** is the workflow that a content/asset for our game goes through from the content building step all the way to the content loading step at runtime within our game.

The following image is a high-level example of the **Content Pipeline** workflow for a single piece of content.

![Content Pipeline Workflow](~/images/tutorials/monogame-tutorials/content-pipeline-extension/content-pipeline-workflow.png)



What we see here is the following
1. The **MonoGame Content Builder** (MGCB) processes the content/asset
    1. First the image file goes through the configured **Importer** which imports all the data from the file itself.
    2. The result of the **Importer** is then passed to the configured **Processor** which does additional processing on the data that was imported.
    3. The result of the **Processor** is then passed to a **Writer** which takes the processed result and writes it to a binary encoded `.xnb` file
2. Processed content `.xnb` files are copied to our game project's build directory when we build our game project by the `MonoGame.Content.Builder.Tasks` NuGet reference in our game.
3. During runtime of the game, when you want to load the asset with the **`ContentManager`**
    1. `Content.Load<T>(string)` is called where `T` is the type of content loaded (`Texture2D` in the example above)
    2. The `.xnb` file matching the name specified in the `Content.Load<T>(string)` method is loaded from disk and sent to the appropriate `ContentTypeReader`
    3. The `ContentTypeReader` reads the contents of the `.xnb` file and produces the resulting object (The `Texture2D` in the example above).

This is the entire Content Pipeline Workflow that all content assets go through.  Hopefully that wasn't too confusing.

Now that we know the entire workflow, we can break down exactly the things we're going to need to create our own extension to load a custom file type

1. An **Importer**
2. A **Processor**
3. A **Writer**
4. A **Reader**

In the next sections we'll go over creating a new **MonoGame Content Pipeline Extension** project where we can create our `ContentTypeImporter`, `ContentTypeProcessor` and `ContentTypeWriter`.  After that we'll move into where and how to create the `ContentTypeReader`.
