using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGames.Entities;

public class Ball
{
    private GraphicsDeviceManager _graphics;

    private Texture2D _texture;
    private Vector2 _position;
    private Vector2 _direction = new Vector2(1f, 1f);
    private Random _random = new Random();
    private float _speed = 200f;
    private Rectangle sourceRectangle;
    private readonly Point _size;

    public Ball(ContentManager content, GraphicsDeviceManager graphics, Point size, Color color)
    {

        _texture = content.Load<Texture2D>("spritesheet_pong");

        _graphics = graphics;
        _size = size;
        sourceRectangle = new Rectangle(25, 0, size.X, size.Y);
        _position = new Vector2((_graphics.PreferredBackBufferWidth - size.X) / 2, (_graphics.PreferredBackBufferHeight - size.Y) / 2);
    }


    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        _position.Y += _direction.Y * deltaTime * _speed;
        _position.X += _direction.X * deltaTime * _speed;

        // Colisão eixo Y (Top/Bottom)
        if (_position.Y <= 0 || _position.Y >= _graphics.PreferredBackBufferHeight - _size.Y)
        {
            // 1. Trava a posição para a bola não ficar presa (vazar) na borda
            _position.Y = MathHelper.Clamp(_position.Y, 0, _graphics.PreferredBackBufferHeight - _size.Y);

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

        // Colisão eixo X (Left/Right)
        if (_position.X <= 0 || _position.X >= _graphics.PreferredBackBufferWidth - _size.X)
        {
            // 1. Trava a posição
            _position.X = MathHelper.Clamp(_position.X, 0, _graphics.PreferredBackBufferWidth - _size.X);

            // 2. Inverte o eixo X exato
            _direction.X *= -1;

            // 3. Muda o ângulo alterando levemente o eixo oposto (Y)
            _direction.Y += (float)(_random.NextDouble() * 0.4 - 0.2);

            // 4. Normaliza
            _direction.Normalize();

            // 5. Aumenta a velocidade
            if (_speed <= 800f) _speed *= 1.1f;
        }

        // Console.WriteLine($"Velocidade: {_speed} | Direção: X={_direction.X:0.00}, Y={_direction.Y:0.00}");
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, sourceRectangle, Color.White);
    }
}
