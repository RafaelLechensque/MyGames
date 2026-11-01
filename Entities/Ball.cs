using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGames.Entities;

public class Ball
{

    private readonly Sprite _sprite;
    private readonly Point _gameBounds;
    private Vector2 _direction = new Vector2(1f, 1f);
    private Random _random = new Random();
    private float _speed = 300f;
    public Rectangle Bounds => _sprite.Bounds;

    public Ball(Sprite sprite, Point gameBounds)
    {
        _sprite = sprite;
        _gameBounds = gameBounds;
    }


    public void Update(GameTime gameTime, Rectangle playerBounds)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        Vector2 position = _sprite.Position;

        position.Y += _direction.Y * deltaTime * _speed;
        position.X += _direction.X * deltaTime * _speed;

        // Colisão eixo Y (Top/Bottom)
        if (position.Y <= 0 || position.Y >= _gameBounds.Y - _sprite.SourceRectangle.Height)
        {
            // 1. Trava a posição para a bola não ficar presa (vazar) na borda
            position.Y = MathHelper.Clamp(position.Y, 0, _gameBounds.Y - _sprite.SourceRectangle.Height);

            // 2. Inverte o eixo Y exato
            _direction.Y *= -1;

            // 3. Muda o ângulo alterando levemente o eixo oposto (X)
            // NextDouble() gera de 0.0 a 1.0. Isso cria uma variação de -0.2 a +0.2
            _direction.X += (float)(_random.NextDouble() * 0.4 - 0.2);

            // 4. Normaliza o vetor para manter o tamanho exato de 1
            _direction.Normalize();

            // 5. Aumenta a velocidade
            if (_speed <= 800f) _speed *= 1.1f;
        }

        Rectangle ballBounds = new(
            (int)position.X,
            (int)position.Y,
            _sprite.Bounds.Width,
            _sprite.Bounds.Height);

        if (_direction.X < 0 && ballBounds.Intersects(playerBounds))
        {
            position.X = playerBounds.Right;
            _direction.X *= -1;
            _direction.Normalize();
        }
        else if (position.X >= _gameBounds.X - _sprite.SourceRectangle.Width)
        {
            position.X = _gameBounds.X - _sprite.SourceRectangle.Width;
            _direction.X *= -1;
            _direction.Normalize();
        }

        _sprite.Position = position;

        // Console.WriteLine($"Velocidade: {_speed} | Direção: X={_direction.X:0.00}, Y={_direction.Y:0.00}");
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch);
    }
}
