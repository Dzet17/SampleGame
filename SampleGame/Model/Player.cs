using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SampleGame.View;

namespace SampleGame.Model
{
	public class Player
	{
		public Player()
		{

public void Initialize(Texture2D texture, Vector2 position)
		{
			PlayerTexture = texture;

			// Set the starting position of the player around the middle of the screen and to the back 
			Position = position;

			// Set the player to be active 
			Active = true;

			// Set the player health
			Health = 100;
		}

		public void Update()
		{
			// Save the previous state of the keyboard and game pad so we can determinesingle key/button presses
			previousGamePadState = currentGamePadState;
			previousKeyboardState = currentKeyboardState;

			// Read the current state of the keyboard and gamepad and store it
			currentKeyboardState = Keyboard.GetState();currentGamePadState = GamePad.GetState(PlayerIndex.One);


//Update the player
UpdatePlayer(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}


private void UpdatePlayer(GameTime gameTime)
{

	// Get Thumbstick Controls
	player.Position.X += currentGamePadState.ThumbSticks.Left.X * playerMoveSpeed;
	player.Position.Y -= currentGamePadState.ThumbSticks.Left.Y * playerMoveSpeed;

	// Use the Keyboard / Dpad
	if (currentKeyboardState.IsKeyDown(Keys.Left) || currentGamePadState.DPad.Left == ButtonState.Pressed)
	{
		player.Position.X -= playerMoveSpeed;
	}
	if (currentKeyboardState.IsKeyDown(Keys.Right) || currentGamePadState.DPad.Right == ButtonState.Pressed)
	{
		player.Position.X += playerMoveSpeed;
	}
	if (currentKeyboardState.IsKeyDown(Keys.Up) || currentGamePadState.DPad.Up == ButtonState.Pressed)
	{
		player.Position.Y -= playerMoveSpeed;
	}
	if (currentKeyboardState.IsKeyDown(Keys.Down) || currentGamePadState.DPad.Down == ButtonState.Pressed)
	{
		player.Position.Y += playerMoveSpeed;
	}

	// Make sure that the player does not go out of bounds
	player.Position.X = MathHelper.Clamp(player.Position.X, 0, GraphicsDevice.Viewport.Width - player.Width);
	player.Position.Y = MathHelper.Clamp(player.Position.Y, 0, GraphicsDevice.Viewport.Height - player.Height);
}

		// Animation representing the player
		private Texture2D playerTexture;
		public Texture2D PlayerTexture
		{
			get { return playerTexture; }
			set { playerTexture = value; }
		}

		// Position of the Player relative to the upper left side of the screen
		// As a struct it cannot be used as a property 😢 sad panda
		public Vector2 Position;

		// State of the player
		private bool active;
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

		// Amount of hit points that player has
		private int health;
		public int Health
		{
			get { return health; }
			set { health = value; }
		}

		// Get the width of the player ship
		public int Width
		{
			get { return PlayerTexture.Width; }
		}

		// Get the height of the player ship
		public int Height
		{
			get { return PlayerTexture.Height; }
		}
	}
}


