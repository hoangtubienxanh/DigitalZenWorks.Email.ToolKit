﻿/////////////////////////////////////////////////////////////////////////////
// <copyright file="Command.cs" company="James John McGuire">
// Copyright © 2021 - 2022 James John McGuire. All Rights Reserved.
// </copyright>
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace DigitalZenWorks.Email.ToolKit.Application
{
	/// <summary>
	/// Represents a command line command.
	/// </summary>
	public class Command
	{
		private readonly string name;
		private readonly IList<CommandOption> options;
		private readonly int parameterCount;

		private string description;
		private IList<string> parameters = new List<string>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Command"/> class.
		/// </summary>
		/// <param name="name">The command name.</param>
		public Command(string name)
		{
			this.name = name;

			if (options == null)
			{
				options = new List<CommandOption>();
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Command"/> class.
		/// </summary>
		/// <param name="name">The command name.</param>
		/// <param name="options">The command options.</param>
		/// <param name="parameterCount">The command parameter count.</param>
		/// <param name="description">The command description.</param>
		public Command(
			string name,
			IList<CommandOption> options,
			int parameterCount,
			string description)
			: this(name)
		{
			this.options = options;
			this.parameterCount = parameterCount;
			this.description = description;
		}

		/// <summary>
		/// Gets or sets the command description.
		/// </summary>
		/// <value>The command description.</value>
		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		/// <summary>
		/// Gets the command name.
		/// </summary>
		/// <value>The command name.</value>
		public string Name { get { return name; } }

		/// <summary>
		/// Gets the command options.
		/// </summary>
		/// <value>The command options.</value>
		public IList<CommandOption> Options { get { return options; } }

		/// <summary>
		/// Gets the command parameter count.
		/// </summary>
		/// <value>The command parameter count.</value>
		public int ParameterCount { get { return parameterCount; } }
	}
}
