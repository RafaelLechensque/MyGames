using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MyGames;

namespace MyGames.Entities;

public class Player
{
    private readonly Sprite _sprite;
    private readonly Point _gameBounds;
    private float _speed = 600f;

    public Player(Sprite sprite, Point gameBounds)
    {
        _sprite = sprite;
        _gameBounds = gameBounds;
    }

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState keyboard = Keyboard.GetState();
        Vector2 position = _sprite.Position;

        if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W))
            position.Y -= _speed * deltaTime;

        if (keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S))
            position.Y += _speed * deltaTime;

        position.Y = MathHelper.Clamp(
            position.Y,
            0,
            _gameBounds.Y - _sprite.Texture.Height);

        _sprite.Position = position;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch);
    }
}
