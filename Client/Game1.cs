using Arch.Core;
using Arch.Persistence;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Client;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Network.Client _client;
    private string _ip;
    private ushort _port;

    private World _world;
    private ArchBinarySerializer _serializer;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: This should come from a config file not hard coded 
        _ip = "127.0.0.1";
        _port = 26769;
        
          
        // TODO: Ip and Port should probably be on the connect function not the object creation.
        _client = new Network.Client();
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        if (Keyboard.GetState().IsKeyDown(Keys.C))
        {
            // TODO: This should happen when player clicks "play" in SP or connect in MP
            _client.Connect($"{_ip}:{_port}"); 
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}