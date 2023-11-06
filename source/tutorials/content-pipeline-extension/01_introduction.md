---
modificationDate: "10/16/2023"
_title: Introduction | MonoGame Content Pipeline Extension Tutorial Series
_description: In this tutorial series, we do a deep dive into creating an extension for the MonoGame Content Pipeline.
---

# MonoGame Content Pipeline Extension Tutorial

> [!VIDEO https://www.youtube.com/embed/fdbGz20q8yk?si=vdk8Wm7xgn7iHshM]

An important part of developing any game is the packaging and optimization of the content assets used in the game.  Content such as images (textures), audio, shaders, and fonts.  When developing games with MonoGame, you are provided the **MonoGame Content Builder Editor** (MGCB Editor) tool to do just that. Using this tool, you can add content to be preprocessed and adjust various configurations for each content type to ensure that it is being processed the way you want it to.

While the MGCB Editor provides support for many common file types and formats used in game development, there are often times where you need it to process custom content types that are not supported out-of-the-box.  To do this, we need to create an extension library that can be used by the MGCB Editor so it knows how to import, process, and write the content to disk as an `.xnb` file.

The purpose of this tutorial is to provide an overview of workflow known as the Content Pipeline and how you can create your own custom extension for the MGCB Editor to process and load custom content types that are not support out-of-the-box by MonoGame.  To keep the scenario for the example simple, we'll create an extension that loads JSON files.

> [!NOTE]
> This tutorial is going to show how to create a **MonoGame Content Pipeline Extension** by going through the steps to create one that is used to read JSON file types.
>
> JSON Files are typically not ideal for processing through the content pipeline as there is actually not much processing that needs to be done.  Writing the JSON to an `.xnb` file may also result in a slightly larger file size than if you just used the JSON file directly due to the additional header information written to an `.xnb` file.
>
> However, I have chosen to use JSON as the example because it is a generally well understood file format and allows this tutorial to focus on the concepts of creating the extension rather than working with complex file types.
