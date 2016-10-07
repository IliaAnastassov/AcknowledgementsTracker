namespace AcknowledgementsTracker.Business.Logic
{
    using System;
    using System.Collections.Generic;
    using DTO;

    public class Printer
    {
        public void PrintAcknowledgements(IEnumerable<AcknowledgementDTO> acknowledgements)
        {
            foreach (var acknowledgement in acknowledgements)
            {
                Console.WriteLine(acknowledgement.Text);

                foreach (var tag in acknowledgement.Tags)
                {
                    Console.Write($"#{tag.Title} ");
                }

                Console.WriteLine($"\nfrom: {acknowledgement.AuthorEmail}\n");
            }
        }
    }
}
