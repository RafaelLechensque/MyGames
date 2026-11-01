using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
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
        Texture2D gameTexture = Content.Load<Texture2D>("spritesheet_pong");
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Sprite ballSprite = new Sprite(
            gameTexture,
            new Vector2((GameBounds.X - 25) / 2, (GameBounds.Y - 25) / 2),
            new Rectangle(25, 0, 25, 25)
        );

        Sprite playerSprite = new Sprite(
            gameTexture,
            new Vector2(10f, (_graphics.PreferredBackBufferHeight - 150) / 2),
            new Rectangle(0, 0, 25, 150)
        );

        _ball = new Ball(ballSprite, GameBounds);
        _player = new Player(playerSprite, GameBounds);
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


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
