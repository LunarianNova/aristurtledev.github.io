# Setup Project

First we need to setup our project so we can get started.  To set it up, we'll create a new C# solution that contains a **MonoGame Game Library** project and a **MonoGame Cross Platform Desktop** (DesktopGL) project.


> [!TIP]
> A **MonoGame Game Library** project is just a standard **C# Class Library** project that comes pre-configured with the MonoGame NuGets and a few common files.

## Create New MonoGame Game Library Project
To first start setting up our new project, we'll need to first create a new **MonoGame Game Library** project.  To do this, complete the following:

# [Visual Studio](#tab/visual-studio)

1. Open Visual Studio and select the **Create a New project** option

![Visual Studio Create a new Project](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-game-library-project/create-new-project.png)

2. In the **Create a new project** window, choose the **MonoGame Game Library (MonoGame Team)** project template and click **Next**

![Choose MonoGame Game Library Template.](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-game-library-project/choose-monogame-game-library-template.png)

3. Choose a name and location for the project.  For the purpose of this tutorial, I have named it **SceneLibrary**.  Once you have chosen a name and location, click the **Create** button.

![Configure MonoGame Game Library Project](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-game-library-project/configure-monogame-game-library-project.png)

4. Once the project is created, you should see the following in the **Solution Explorer** panel:

![Solution Explorer Panel Result](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-game-library-project/solution-explorer-panel-result.png)


# [VS Code](#tab/visual-studio-code)

1. Create a new directory somewhere on your computer that will hold our project.  For example on your Desktop.  For the purposes of this tutorial, I have called my directory **SceneLibrary**

![Create SceneLibrary Directory](~/images/tutorials/scenes/03_setup-project/vs-code/create-new-monogame-game-library-project/create-directory.png)

2. Next, open Visual Studio Code and choose **Open Folder** in the **Explorer Panel**.  Then choose to open the **SceneLibrary** directory we just created.

![Open Directory](~/images/tutorials/scenes/03_setup-project/vs-code/create-new-monogame-game-library-project/open-folder.png)

3. Once the directory is open in Visual Studio Code, open a new **Terminal Panel** by pressing `` CTRL+` `` or choosing **View > Terminal** from the top menu

![View Terminal](~/images/tutorials/scenes/03_setup-project/vs-code/create-new-monogame-game-library-project/view-terminal.png)

4. In the **Terminal Panel** that opens at the bottom enter the following commands.  These commands will create a new solution named **SceneLibrary**, then create a new **MonoGame Game Library** project called **SceneLibrary**, and finally add the library to the solution file:

```sh
dotnet new sln -n SceneLibrary
dotnet new mglib -n SceneLibrary
dotent sln add ./SceneLibrary
```

Once the project is created, you should see the following in the **Explorer** panel:

![Explorer Panel](~/images/tutorials/scenes/03_setup-project/vs-code/create-new-monogame-game-library-project/solution-explorer.png)

---


## Setup the MonoGame Game Library Project
Next, we need to adjust our **MonoGame Game Library** project for what we are creating. To do this, complete the following

# [Visual Studio](#tab/visual-studio)

1. For the purposes of what we are creating we do not need the **Content** directory or the **Game1.cs** file here, so delete both of these

> [!NOTE]
> The **Content** directory and **Game1.cs** file can be useful when creating a full MonoGame game library, however we don't need them for our purposes.

2. Right-click on the **SceneLibrary** project and select **Add > New Class**

![Add New Class](~/images/tutorials/scenes/03_setup-project/visual-studio/setup-monogame-game-library-project/add-new-class.png)

3. In the **Add New Item** window, name the new class file **Scene.cs** then click the **Add** button to add it to our project.

![Name Scene.cs](~/images/tutorials/scenes/03_setup-project/visual-studio/setup-monogame-game-library-project/name-scene-cs.png)

# [VS Code](#tab/visual-studio-code)

1. For the purposes of what we are creating, we do not need the **Content** direcotry or the **Game1.cs** file here, so delete both of these

> [!NOTE]
> The *Content* directory and *Game1.cs* file can be useful when creating a full MonoGame game library, however we don't need them for our purposes.

2. In the **Explorer Panel** right-click on the **SceneLibrary** project directory and choose **New File**.  Name the new file **Scene.cs**

![New File](~/images/tutorials/scenes/03_setup-project/vs-code/setup-monogame-game-library-project/new-file.png)

![Scene.cs File](~/images/tutorials/scenes/03_setup-project/vs-code/setup-monogame-game-library-project/scene-cs.png)

---

## Create new MonoGame Cross Platform Desktop Project

Next, we'll need to create a new **MonoGame Cross Platform Desktop** project that we can use to test out our **SceneLibrary** and see it in action when we set it all up.

To do this, complete the following

# [Visual Studio](#tab/visual-studio)

1. In the **Solution Explorer** panel, right click on the **SceneLibrary** solution and choose **Add > New Project**

![Add New Project](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-crossplatform-project/add-new-project.png)

2. In the **Add new project** window, choose the **MonoGame Cross-Platform Desktop Application (MonoGame Team)** project template, then click the **Next** button.

![Choose MonoGame Cross-Platform Template](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-crossplatform-project/choose-monogame-crossplatform-template.png)

3. In the **Configure your new project** window, enter a name for your project then click the **Create** button.  For the purposes of this tutorial, I have named my project **ExampleGame**.

![Configure MonoGame Cross-Platform Project](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-crossplatform-project/configure-monogame-crossplatform-project.png)

4. Once created, you're **Solution Explorer** panel should now look similar to the following with both our **MonoGame Cross-Platform Desktop Application** project and the **MonoGame Game Library** project.

![Visual Studio Solution Explorer Final](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-crossplatform-project/solution-explorer-result.png)

5. Finally, we need to add a project reference to the **SceneLibrary** project in our **ExampleGame** project. To do this, right-click on the **ExampleGame** project in the **Solution Explorer** and select

![Add New Reference](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-crossplatform-project/add-new-reference.png)

Then in the **Reference Manager** window, check the box next to **SceneLibrary** to add it as a reference, then click the **Ok** button at the bottom.

![Reference Scene Library](~/images/tutorials/scenes/03_setup-project/visual-studio/create-new-monogame-crossplatform-project/reference-scenelibrary-project.png)








# [VS Code](#tab/visual-studio-code)

1. In the **Terminal Panel** that we opened previously at the bottom, enter the following commands.  These commands will create a new **MonoGame Cross-Platform Desktop Project** game project, add it to our solution file, then perform a restore on both the **SceneLibrary** and **ExampleGame** projects:

```sh
dotnet new mgdesktopgl -n ExampleGame
dotnet sln add ./ExampleGame
dotnet restore
```

Once finished, the files in the **Explorer Panel** should like like the following:

![Scene.cs File](~/images/tutorials/scenes/03_setup-project/vs-code/create-new-monogame-crossplatform-project/explorer-panel.png)


---

## Next Steps
Now that we have our base project setup, on the next page we'll setup the code for our **Scene.cs** class and go over it.

