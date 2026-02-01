using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleAnimationNamespace;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _SpaceBackground;
    private Texture2D _Astronaut;
    private Texture2D _Astronaut2;

    private SpriteFont _Arial;

    private SimpleAnimation _jupiterAnimation;
    private SimpleAnimation _ufoAnimation;

    private Vector2 _AVelocity;
    private Vector2 _APosition;
    private Vector2 _UfoVelocity;
    private Vector2 _UfoPosition;

    private float _ufoSpeed = 200f;
    private float _speed = 50f;

    private float deltaTime;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _APosition = new Vector2(100, 100);
        _AVelocity = new Vector2(-1f, -1f);

        _UfoPosition = new Vector2(400, 300);
        _UfoVelocity = new Vector2(1f, 1f);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _SpaceBackground = Content.Load<Texture2D>("Space Background");
        _Astronaut = Content.Load<Texture2D>("ASTRONAUT");
        _Astronaut2 = Content.Load<Texture2D>("ASTRONAUT2");

        _Arial = Content.Load<SpriteFont>("File");

        _jupiterAnimation = new SimpleAnimation(Content.Load<Texture2D>("jupiter-128x128"), 128, 128, 6, 1);
        _ufoAnimation = new SimpleAnimation(Content.Load<Texture2D>("UFO"), 240, 360, 8, 10);

    }

    protected override void Update(GameTime gameTime)
    {
        _jupiterAnimation.Update(gameTime);
        _ufoAnimation.Update(gameTime);

        deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
    
        _APosition += _AVelocity * _speed * deltaTime;

        HandleUfoMovement();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(_SpaceBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

        _spriteBatch.Draw(_Astronaut, _APosition, Color.White);
        _spriteBatch.Draw(_Astronaut2, new Vector2(100, 200), Color.White);

        _jupiterAnimation.Draw(_spriteBatch, new Vector2(500, 100), SpriteEffects.None);

        _ufoAnimation.Draw(_spriteBatch, _UfoPosition, SpriteEffects.None);

        _spriteBatch.DrawString(_Arial, "Welcome to Space", new Vector2(230, 30), Color.Purple);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void HandleUfoMovement()
    {
        KeyboardState state = Keyboard.GetState();

        if (state.IsKeyDown(Keys.W))
        {
            _UfoPosition.Y -= _UfoVelocity.Y * _ufoSpeed * deltaTime;
            
        }
        if (state.IsKeyDown(Keys.S))
        {
            _UfoPosition.Y += _UfoVelocity.Y * _ufoSpeed * deltaTime;
           
        }
        if (state.IsKeyDown(Keys.A))
        {
            _UfoPosition.X -= _UfoVelocity.X * _ufoSpeed * deltaTime;
            
        }
        if (state.IsKeyDown(Keys.D))
        {
            _UfoPosition.X += _UfoVelocity.X * _ufoSpeed * deltaTime;

        }
            
    }

}
