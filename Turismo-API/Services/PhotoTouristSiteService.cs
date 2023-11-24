using Firebase.Auth;
using Firebase.Storage;
using Turismo_API.Models.Custom;
using Turismo_API.Services.Interfaces;

namespace Turismo_API.Services
{
    public class PhotoTouristSiteService : IPhotoTouristSiteService
    {
        private static readonly string Apikey = "AIzaSyBT1FwvIwJ_-frz2iL2qGjdQcZO9xidJhw";
        private static readonly string Bucket = "turismotiquipaya.appspot.com";
        private static readonly string AuthEmail = "Tur1smoTiquipaya@admin.com";
        private static readonly string AuthPassword = "Tur1smoTiquipay@123#";

        public async Task<List<string>> UploadImages(List<string> images, string name)
        {
            var imagesURL = new List<string>();
            int imageCounter = 1;

            foreach (var base64Image in images)
            {
                ImageDTO imageDTO = new ImageDTO
                {
                    Image = base64Image,
                    ImageName = name + imageCounter,
                    FolderName = "Sites",
                };

                string imageFromFirebase = await GetAll(imageDTO);
                imagesURL.Add(imageFromFirebase);
                imageCounter++;
            }

            return imagesURL;
        }

        private static async Task<string> GetAll(ImageDTO model)
        {
            var imageFromBase64ToStream = ConvertB64ToStream(model.Image);
            var imageStream = imageFromBase64ToStream.ReadAsStream();
            string imageFromFirebase = await UpToFirebase(imageStream, model);
            return imageFromFirebase;
        }

        private static StreamContent ConvertB64ToStream(string imageFromRequest)
        {
            byte[] imageStringToBase64 = Convert.FromBase64String(imageFromRequest);
            StreamContent streamContent = new(new MemoryStream(imageStringToBase64));
            return streamContent;
        }

        private static async Task<string> UpToFirebase(Stream stream, ImageDTO imageDTO)
        {
            string imageFromFirebaseStorage = "";
            FirebaseAuthProvider firebaseConfiguration = new(new FirebaseConfig(Apikey));

            FirebaseAuthLink authConfiguration = await firebaseConfiguration
                .SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            CancellationTokenSource cancellationToken = new();

            FirebaseStorageTask storageManager = new FirebaseStorage(Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authConfiguration.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(imageDTO.FolderName)
                .Child(imageDTO.ImageName)
                .PutAsync(stream, cancellationToken.Token);

            try
            {
                imageFromFirebaseStorage = await storageManager;
            }
            catch
            {
            }
            return imageFromFirebaseStorage;
        }

    }
}
