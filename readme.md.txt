#Snake and ladders kata
This solution is composed of 3 projects
1.- ConsoleApplication: It's a console application, show a text interface shows an interface with what happens in the game. 
						In the first step the players can introduce the number of players with the keyboard and can confirm with enter and
						later they can press any key for roll the dice and can see the results.
2.- Domain: It's the class library and it's prepared for implement with the ConsoleApplication or a future Backend application, this library contains
			the 3 basic classes for this domain Game with the game events, player for control the player status and actions and dice for control the dice behaviour
			"In the future you'll can have different types of dice".
3.- Domain.UnitTests: Include the Unit tests of the kata for check the application.