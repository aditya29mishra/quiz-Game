using System.Collections.Generic;
using Firebase.Firestore;
using UnityEngine;

public class FirestoreDataUploader : MonoBehaviour
{
    private FirebaseFirestore firestore;

    void Start()
    {
        firestore = FirebaseFirestore.DefaultInstance;
        UploadDummyData();
    }

    //Dummy data for the quiz genrated by CHAT GPT 
    void UploadDummyData()
    {
        Dictionary<string, object> computerQuiz = new Dictionary<string, object>
        {
            { "questions", new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>{
                        {"question", "What is the capital of France?"},
                        {"options", new List<string>{ "Paris", "Berlin", "Madrid", "Rome" }},
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{
                        {"question", "What is 2 + 2?"},
                        {"options", new List<string>{ "3", "4", "5", "6" }},
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{
                        {"question", "What is the color of the sky on a clear day?"},
                        {"options", new List<string>{ "Blue", "Green", "Red", "Yellow" }},
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{
                        {"question", "What is the boiling point of water?"},
                        {"options", new List<string>{ "90°C", "100°C", "120°C", "80°C" }},
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{
                        {"question", "Who painted the Mona Lisa?"},
                        {"options", new List<string>{ "Leonardo da Vinci", "Pablo Picasso", "Vincent van Gogh", "Claude Monet" }},
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{
                        {"question", "What is the largest desert on Earth?"},
                        {"options", new List<string>{ "Sahara", "Antarctica", "Gobi", "Kalahari" }},
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{
                        {"question", "Which is the smallest ocean on Earth?"},
                        {"options", new List<string>{ "Indian", "Pacific", "Arctic", "Atlantic" }},
                        {"correctOption", 2}
                    },
                    new Dictionary<string, object>{
                        {"question", "What is the primary ingredient in guacamole?"},
                        {"options", new List<string>{ "Avocado", "Tomato", "Lettuce", "Onion" }},
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{
                        {"question", "What is the fastest land animal?"},
                        {"options", new List<string>{ "Cheetah", "Lion", "Horse", "Kangaroo" }},
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{
                        {"question", "Which gas do plants exhale at night?"},
                        {"options", new List<string>{ "Oxygen", "Carbon Dioxide", "Nitrogen", "Hydrogen" }},
                        {"correctOption", 1}
                    },

                }
            }
        };

        Dictionary<string, object> lampQuiz = new Dictionary<string, object>
        {
            { "questions", new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>{ 
                        {"question", "What is the boiling point of water?"}, 
                        {"options", new List<string>{ "90°C", "100°C", "120°C", "80°C" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which gas do plants exhale at night?"}, 
                        {"options", new List<string>{ "Oxygen", "Carbon Dioxide", "Nitrogen", "Helium" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the color of the sun?"}, 
                        {"options", new List<string>{ "Yellow", "Red", "White", "Orange" }}, 
                        {"correctOption", 2}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the closest planet to the Sun?"}, 
                        {"options", new List<string>{ "Mercury", "Venus", "Earth", "Mars" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which country has the most population?"}, 
                        {"options", new List<string>{ "India", "China", "USA", "Russia" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the national animal of India?"}, 
                        {"options", new List<string>{ "Tiger", "Lion", "Elephant", "Peacock" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which continent has the most countries?"}, 
                        {"options", new List<string>{ "Asia", "Africa", "Europe", "South America" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the name of the largest bone in the human body?"}, 
                        {"options", new List<string>{ "Femur", "Tibia", "Humerus", "Fibula" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the main ingredient of bread?"}, 
                        {"options", new List<string>{ "Flour", "Rice", "Potato", "Corn" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the square root of 16?"}, 
                        {"options", new List<string>{ "2", "4", "6", "8" }}, 
                        {"correctOption", 1}
                    },

                }
            }
        };

        Dictionary<string, object> globeQuiz = new Dictionary<string, object>
        {
            { "questions", new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>{ 
                        {"question", "Which is the largest ocean on Earth?"}, 
                        {"options", new List<string>{ "Atlantic", "Pacific", "Indian", "Arctic" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "How many continents are there?"}, 
                        {"options", new List<string>{ "5", "6", "7", "8" }}, 
                        {"correctOption", 2}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the tallest mountain on Earth?"}, 
                        {"options", new List<string>{ "K2", "Mount Everest", "Kilimanjaro", "Denali" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which is the hottest planet in the solar system?"}, 
                        {"options", new List<string>{ "Venus", "Mercury", "Mars", "Earth" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the longest river on Earth?"}, 
                        {"options", new List<string>{ "Amazon", "Nile", "Yangtze", "Mississippi" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the coldest place on Earth?"}, 
                        {"options", new List<string>{ "Siberia", "Antarctica", "Greenland", "Iceland" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the deepest point in the ocean?"}, 
                        {"options", new List<string>{ "Challenger Deep", "Mariana Trench", "Tonga Trench", "Java Trench" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which desert is the largest hot desert?"}, 
                        {"options", new List<string>{ "Gobi", "Sahara", "Kalahari", "Mojave" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the capital of Japan?"}, 
                        {"options", new List<string>{ "Tokyo", "Kyoto", "Osaka", "Hiroshima" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which is the second smallest continent?"}, 
                        {"options", new List<string>{ "Europe", "Australia", "South America", "Antarctica" }}, 
                        {"correctOption", 1}
                    },

                }
            }
        };

        Dictionary<string, object> bookQuiz = new Dictionary<string, object>
        {
            { "questions", new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>{ 
                        {"question", "Who wrote 'Romeo and Juliet'?"}, 
                        {"options", new List<string>{ "Charles Dickens", "William Shakespeare", "Mark Twain", "J.K. Rowling" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the first letter of the Greek alphabet?"}, 
                        {"options", new List<string>{ "Alpha", "Beta", "Gamma", "Delta" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Who is the author of '1984'?"}, 
                        {"options", new List<string>{ "George Orwell", "Aldous Huxley", "Ray Bradbury", "Kurt Vonnegut" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the largest library in the world?"}, 
                        {"options", new List<string>{ "British Library", "Library of Congress", "New York Public Library", "National Library of China" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Who wrote 'The Great Gatsby'?"}, 
                        {"options", new List<string>{ "Ernest Hemingway", "F. Scott Fitzgerald", "John Steinbeck", "Harper Lee" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the most translated book in the world?"}, 
                        {"options", new List<string>{ "The Bible", "The Quran", "Harry Potter", "Don Quixote" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Who wrote 'To Kill a Mockingbird'?"}, 
                        {"options", new List<string>{ "Mark Twain", "Harper Lee", "Jane Austen", "Charlotte Brontë" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the longest book ever written?"}, 
                        {"options", new List<string>{ "War and Peace", "Remembrance of Things Past", "Infinite Jest", "The Stand" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What genre is '1984'?"}, 
                        {"options", new List<string>{ "Dystopian", "Fantasy", "Romance", "Science Fiction" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the last letter of the Greek alphabet?"}, 
                        {"options", new List<string>{ "Alpha", "Omega", "Beta", "Delta" }}, 
                        {"correctOption", 1}
                    },

                }
            }
        };

        Dictionary<string, object> paintingQuiz = new Dictionary<string, object>
        {
            { "questions", new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>{ 
                        {"question", "Who painted the Mona Lisa?"}, 
                        {"options", new List<string>{ "Vincent van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Claude Monet" }}, 
                        {"correctOption", 2}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which country is famous for its Ukiyo-e art?"}, 
                        {"options", new List<string>{ "China", "Japan", "India", "Korea" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What is the art movement of Van Gogh?"}, 
                        {"options", new List<string>{ "Impressionism", "Post-Impressionism", "Cubism", "Expressionism" }}, 
                        {"correctOption", 1}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which artist painted 'Starry Night'?"}, 
                        {"options", new List<string>{ "Van Gogh", "Picasso", "Monet", "Dali" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Who is considered the father of modern art?"}, 
                        {"options", new List<string>{ "Cezanne", "Van Gogh", "Picasso", "Matisse" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Which artist is known for 'Persistence of Memory'?"}, 
                        {"options", new List<string>{ "Dali", "Monet", "Matisse", "Warhol" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What medium is typically used in Ukiyo-e art?"}, 
                        {"options", new List<string>{ "Woodblock prints", "Oil painting", "Charcoal", "Ink" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "Who painted 'The Last Supper'?"}, 
                        {"options", new List<string>{ "Leonardo da Vinci", "Michelangelo", "Raphael", "Titian" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What style is 'The Scream' by Edvard Munch?"}, 
                        {"options", new List<string>{ "Expressionism", "Surrealism", "Cubism", "Realism" }}, 
                        {"correctOption", 0}
                    },
                    new Dictionary<string, object>{ 
                        {"question", "What art movement is Claude Monet associated with?"}, 
                        {"options", new List<string>{ "Impressionism", "Expressionism", "Cubism", "Surrealism" }}, 
                        {"correctOption", 0}
                    },

                }
            }
        };
        UploadQuizData("ComputerQuiz", computerQuiz);
        UploadQuizData("LampQuiz", lampQuiz);
        UploadQuizData("GlobeQuiz", globeQuiz);
        UploadQuizData("BookQuiz", bookQuiz);
        UploadQuizData("PaintingQuiz", paintingQuiz);
    }

    void UploadQuizData(string documentId, Dictionary<string, object> quizData)
    {
        firestore.Collection("objects").Document(documentId).SetAsync(quizData);
    }
}
