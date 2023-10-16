protected override void LoadContent()
{
    _spriteBatch = new SpriteBatch(GraphicsDevice);

    // TODO: use this.Content to load your game content here
    ExampleModel example = Content.Load<ExampleModel>("example");
}