﻿namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using Model;

    public class Printer
    {
        public void PrintAcknowledgements(ICollection<Acknowledgement> acknowledgements)
        {
            foreach (var acknowledgement in acknowledgements)
            {
                Console.WriteLine(acknowledgement.Text);

                foreach (var tag in acknowledgement.Tags)
                {
                    Console.Write($"#{tag.Title} ");
                }

                Console.WriteLine($"\nfrom: {acknowledgement.Author.UserName}\n");
            }
        }
    }
}