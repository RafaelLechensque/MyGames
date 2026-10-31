using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGames.Entities;

namespace MyGames;

public class Game1 : Game
{

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Point GameBounds = new Point(1280, 720); //window resolution

    private Ball _ball;
    private Player _player;
    // private Texture2D _pixelTexture;
    // private Vector2 _playerPosition;
    // private readonly Point _playerSize = new Point(50, 50);
    // private float _playerSpeed = 250f;
    // Start do jogo, pirmeiras variaveis
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        Window.Title = "My Game";

        _graphics.PreferredBackBufferWidth = GameBounds.X;
        _graphics.PreferredBackBufferHeight = GameBounds.Y;
        IsMouseVisible = true;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        // Texture2D playerTexture = Content.Load<Texture2D>("sprites/player");
        _ball = new Ball(Content, _graphics, new Point(25, 25), Color.Black);
        _player = new Player(Content, _graphics, new Vector2(10f, (_graphics.PreferredBackBufferHeight - 150) / 2));
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _ball.Update(gameTime);
        _player.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _ball.Draw(_spriteBatch);
        _player.Draw(_spriteBatch);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
