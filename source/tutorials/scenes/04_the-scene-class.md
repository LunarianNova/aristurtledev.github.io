# The Scene Class
In this part of the tutorial, we are going to add the code necessary to our **Scene.cs** class file.  This class will be the foundation for all scenes we create within our game.

Open the **Scene.cs** class file and replace the content of it with the following.  We'll go over what each part of it is doing after.

```cs
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public abstract class Scene
{
    //  A cached reference to our Game instance.
    protected Game _game;

    //  Used to load scene specific content
    protected ContentManager _content;

    /// <summary>
    ///     Creates a new Scene instance.
    /// </summary>
    /// <param name="game">
    ///     A reference to our Game1 instance.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if the value supplied for <paramref name="game"/>
    ///     is null
    /// </exception>
    public Scene(Game game)
    {
        //  Ensure the game reference given is not null
        if (game == null)
        {
            throw new ArgumentNullException(nameof(game), "Game cannot be null!");
        }

        _game = game;
    }

    /// <summary>
    ///     Initializes the Scene
    /// </summary>
    /// <remarks>
    ///     This is called only once, immediately after the scene becomes
    ///     the active scene, and before the first Update is called on
    ///     the scene
    /// </remarks>
    public virtual void Initialize()
    {
        _content = new ContentManager(_game.Services);
        _content.RootDirectory = _game.Content.RootDirectory;
        LoadContent();
    }

    /// <summary>
    ///     Loads the content specific to the Scene.
    /// </summary>
    /// <remarks>
    ///     This is called internally by the Initialize() method.
    /// </remarks>
    protected virtual void LoadContent() { }

    /// <summary>
    ///     Unloads any content that has been loaded by the scene.
    /// </summary>
    /// <remarks>
    ///     This will be called after the game switches to a new
    ///     scene.
    /// </remarks>
    public virtual void UnloadContent()
    {
        _content.Unload();
        _content = null;
    }

    /// <summary>
    ///     Updates the Scene.
    /// </summary>
    /// <param name="gameTime">
    ///     A snapshot of the frame specific timing values.
    /// </param>
    public virtual void Update(GameTime gameTime) { }


    /// <summary>
    ///     Handles preparing the Scene to draw.
    /// </summary>
    /// <remarks>
    ///     This is called just before the main Draw method.
    /// </remarks>
    /// <param name="spriteBatch"></param>
    public virtual void BeforeDraw(SpriteBatch spriteBatch, Color clearColor)
    {
        _game.GraphicsDevice.Clear(clearColor);
        spriteBatch.Begin();
    }

    /// <summary>
    ///     Draws the Scene to the screen.
    /// </summary>
    /// <remarks>
    ///     This is called immediately after BeforeDraw.
    /// </remarks>
    /// <param name="spriteBatch">
    ///     The SpriteBatch instance used for rendering.
    /// </param>
    public virtual void Draw(SpriteBatch spriteBatch) { }

    /// <summary>
    ///     Handles ending any drawing the scene is performing.
    /// </summary>
    /// <remarks>
    ///     This is called immediately after Draw.
    /// </remarks>
    /// <param name="spriteBatch">
    ///     The SpriteBatch instance used for rendering.
    /// </param>
    public virtual void AfterDraw(SpriteBatch spriteBatch)
    {
        spriteBatch.End();
    }
}
```

## Fields
The `Scene` class has two fields; `_game` and `_content`.

```cs
//  A cached reference to our Game instance.
protected Game _game;

//  Used to load scene specific content
protected ContentManager _content;
```

We can use the `_game` field to access some of the usual stuff like `Game.GraphicsDevice`.

The `_content` field will be used to load content that is specific to the scene.  This will be a separate `ContentManager` instance from the one in our `Game1` instance.  This has two benefits

1. All content loaded from the `Game1` class will act as a sort of global content manager, since it's accessible from any scene through `_game.Content`.  Thsi would be assets like fonts and audio that are used in multiple scenes
2. By each scene having its own content manager, this means we don't have to load every asset up front at runtime; instead we only load the global assets first as to point #1 above.  Then, when we switch to our scene, we can load the scene specific stuff for that scene and unload it when the scene is finished.  This means a smaller memory footprint throughout the game's life cycle.

## Constructor
Next, we'll take a look at the constructor

```cs
/// <summary>
///     Creates a new Scene instance.
/// </summary>
/// <param name="game">
///     A reference to our Game1 instance.
/// </param>
/// <exception cref="ArgumentNullException">
///     Thrown if the value supplied for <paramref name="game"/>
///     is null
/// </exception>
public Scene(Game game)
{
    if (game == null)
    {
        throw new ArgumentNullException(nameof(game), "Game cannot be null!");
    }

    _game = game;
}
```

As far as constructors go, this one is pretty simple.  It takes an instance of the `Game` class as the only parameter.  A check is made to ensure that the `game` parameter given isn't null and throws an `ArgumentNullException` if it is; otherwise, we cache the reference in out `_game` field.

## Initialize()
The `Initialize()` method is where all the initializations will be performed for our scene.

```cs
/// <summary>
///     Initializes the Scene
/// </summary>
/// <remarks>
///     This is called only once, immediately after the scene becomes
///     the active scene, and before the first Update is called on
///     the scene
/// </remarks>
public virtual void Initialize()
{
    _content = new ContentManager(_game.Services);
    _content.RootDirectory = _game.Content.RootDirectory;
    LoadContent();
}
```

An important thing to note here is this is where the `_content` field is initialized, and immediatly the `LoadContent()` method is called.  This is to ensure that all content is loaded before the implementing scene finishes initializing.  This mimics the same process that the `Game` class uses in MonoGame.

In the order of events, `Initialize()` will be called on the same frame that the scene is set as the active scene, and before the first `Update(GameTime)` is called on the scene.

## LoadContent()
The `LoadContent()` method is where all the content for the scene will be loaded.

```cs
/// <summary>
///     Loads the content specific to the Scene.
/// </summary>
/// <remarks>
///     This is called internally by the Initialize() method.
/// </remarks>
protected virtual void LoadContent() { }
```

As we went over in the [Initialize](#initialize) section, `LoadContent()` is called from within the `Initialize()` method.

## UnloadContent()
The `UnloadContent()` method allows us to unload any content loaded by the scene when the scene ends. This cleans up any resources that are no longer needed.

```cs
/// <summary>
///     Unloads any content that has been loaded by the scene.
/// </summary>
/// <remarks>
///     This will be called after the game switches to a new
///     scene.
/// </remarks>
public virtual void UnloadContent()
{
    _content.Unload();
    _content = null;
}
```

When we switch from one scene to another, `UnloadContent()` will be called to unload any assets before the next scene is loaded.

## Update(GameTime)
The `Update(GameTime)` method is pretty simple.

```cs
/// <summary>
///     Updates the Scene.
/// </summary>
/// <param name="gameTime">
///     A snapshot of the frame specific timing values.
/// </param>
public virtual void Update(GameTime gameTime) { }
```

We'll use this to handle all update logic for the scene.

## BeforeDraw(SpriteBatch, Color)
Here, in the `BeforeDraw(SpriteBatch, Color)` method, we'll handle preparing hte scene for rendering to the screen.

```cs
/// <summary>
///     Handles preparing the Scene to draw.
/// </summary>
/// <remarks>
///     This is called just before the main Draw method.
/// </remarks>
/// <param name="spriteBatch"></param>
public virtual void BeforeDraw(SpriteBatch spriteBatch, Color clearColor)
{
    _game.GraphicsDevice.Clear(clearColor);
    spriteBatch.Begin();
}
```

This method will take two parameters; a `SpriteBatch` instance and a `Color` value.  The base method will clear the backbuffer using the `Color` value given, then call `SpriteBatch.Begin()`

## Draw(SpriteBatch)

Immediately after `BeforeDraw(SpriteBatch, Color)` is called, we'll call `Draw(SpriteBatch)`.

```cs
/// <summary>
///     Draws the Scene to the screen.
/// </summary>
/// <remarks>
///     This is called immediately after BeforeDraw.
/// </remarks>
/// <param name="spriteBatch">
///     The SpriteBatch instance used for rendering.
/// </param>
public virtual void Draw(SpriteBatch spriteBatch) { }
```

This will take in the same `SpriteBatch` instance that was used in the `BeforeDraw(SpriteBatch, Color)` method so we can use it to render to the screen.

## AfterDraw(SpriteBatch)
Finally, we have the `AfterDraw(SpriteBatch)` method.  This is called immediately after `Draw(SpriteBatch)`.

```cs
/// <summary>
///     Handles ending any drawing the scene is performing.
/// </summary>
/// <remarks>
///     This is called immediately after Draw.
/// </remarks>
/// <param name="spriteBatch">
///     The SpriteBatch instance used for rendering.
/// </param>
public virtual void AfterDraw(SpriteBatch spriteBatch)
{
    spriteBatch.End();
}
```

This takes the same `SpriteBatch` instance that was used in the `BeforeDraw(SpriteBatch, Color)` and `Draw(SpriteBatch)`.  In the base method, we just simply call `SpriteBatch.End()` to signal that we are done drawing.

## Next Steps
Now that we have created our `Scene` class, on the next page we're going to update our **Game1.cs** game file to make use of the `Scene` class we just created.
