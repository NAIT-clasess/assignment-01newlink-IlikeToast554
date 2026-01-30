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

    private Vector2 _velocity;
    private Vector2 _position;
    private float _speed = 50f;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _position = new Vector2(100, 100);
        _velocity = new Vector2(-1f, -1f); 

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

    }

    protected override void Update(GameTime gameTime)
    {
        _jupiterAnimation.Update(gameTime);

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _position += _velocity * _speed * deltaTime;

        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(_SpaceBackground, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

        _spriteBatch.Draw(_Astronaut, _position, Color.White);
        _spriteBatch.Draw(_Astronaut2, new Vector2(100, 200), Color.White);

        _jupiterAnimation.Draw(_spriteBatch, new Vector2(500, 100), SpriteEffects.None);

        _spriteBatch.DrawString(_Arial, "Welcome to Space", new Vector2(230, 30), Color.Purple);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
