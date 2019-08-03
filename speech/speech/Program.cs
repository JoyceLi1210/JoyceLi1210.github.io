using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace helloworld
{
    class Program
    {

        public static async Task RecognizeSpeechAsync()
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key // and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription("9679c4f1753a444caefd13b75166c720", "westus");

            // Creates a speech recognizer.
            using (var recognizer = new SpeechRecognizer(config))
            {
                Console.WriteLine("Say something...");

                // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                // single utterance is determined by listening for silence at the end or until a maximum of 15
                // seconds of audio is processed.  The task returns the recognition text as result. 
                // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                // shot recognition like command or query. 
                // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
                var result = await recognizer.RecognizeOnceAsync();

                // Checks result.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"I think you say that >  {result.Text}");
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }

                //
                using (var synthesizer = new SpeechSynthesizer(config))
                {
                    // Receive a text from console input and synthesize it to speaker.
                    string text = result.Text;

                    if (result.Text == "What do you want to do?")
                    {
                        using (var result1 = await synthesizer.SpeakTextAsync("I want to sleep all day"))
                        {
                            if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                            {
                                Console.WriteLine($"Speech synthesized to speaker for text [{result1}]");

                            }
                            else if (result.Reason == ResultReason.Canceled)
                            {
                                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result1);
                                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                                if (cancellation.Reason == CancellationReason.Error)
                                {
                                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                                    Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                                    Console.WriteLine($"CANCELED: Did you update the subscription info?");
                                }
                            }
                        }
                    }
                    else
                    {
                        using (var result1 = await synthesizer.SpeakTextAsync("i don't know."))
                        {
                            if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                            {
                                Console.WriteLine($"Speech synthesized to speaker for text [{result1}]");

                            }
                            else if (result.Reason == ResultReason.Canceled)
                            {
                                var cancellation = SpeechSynthesisCancellationDetails.FromResult(result1);
                                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                                if (cancellation.Reason == CancellationReason.Error)
                                {
                                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                                    Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                                    Console.WriteLine($"CANCELED: Did you update the subscription info?");
                                }
                            }
                        }

                    }
                }
            }
        }


        static void Main()
        {
            while (true)
            {
                RecognizeSpeechAsync().Wait();

                Console.WriteLine("Please press a key to continue.");
                Console.ReadLine();
            }
        }
    }
}