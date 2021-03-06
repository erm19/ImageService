﻿using ImageService.Commands;
using ImageService.Infrastructure;
using ImageService.Infrastructure.Enums;
using ImageService.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageService.Controller
{
    public class ImageController : IImageController
    {
        private IImageServiceModal m_modal; // The Modal Object
        private Dictionary<int, ICommand> commands;

        /// <summary>
        /// Constructor for ImageController.
        /// </summary>
        /// <param name="modal"> Image service modal. </param>
        public ImageController(IImageServiceModal modal)
        {
            //storing the system's modal.
            m_modal = modal; 
            commands = new Dictionary<int, ICommand>()
            {
                {(int)CommandEnum.NewFileCommand, new NewFileCommand(m_modal) }
            };
        }

        /// <summary>
        /// Executes the command using the right Command.
        /// </summary>
        /// <param name="commandID"> The command. </param>
        /// <param name="args"> Arguments. </param>
        /// <param name="resultSuccesful"> If it succeded</param>
        /// <returns></returns>
        public string ExecuteCommand(int commandID, string[] args, out bool resultSuccesful)
        {
            if (commands.ContainsKey(commandID))
            {
                Console.WriteLine("executing command");
                return commands[commandID].Execute(args, out resultSuccesful);
            }
            else
            {
                resultSuccesful = false;
                return "command not found";
            }
        }
    }
}
