using System;
using SportDirect.Extenstions;
using Xamarin.Forms;

namespace SportDirect.Controls
{
    public class PinchAndPanContainer : ContentView
    {
        double currentScale = 1;
        double startScale = 1;
        double xOffset = 0;
        double yOffset = 0;

        // In this class we are Initialization the Gesture Recognizers for the particular property
        public PinchAndPanContainer()
        {
            PinchGestureRecognizer pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += PinchGesture_PinchUpdated;
            GestureRecognizers.Add(pinchGesture);

            //Rises the OnPanUpdated Event
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }
        private void PinchGesture_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            /* Storing the current Scale Factor of both Horizontal and Vertical Orientations with Anchor X an Anchor         Y This defines the Centralization of any image to the particular Orientations. */

            if (e.Status == GestureStatus.Started)
            {
                // We Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.

                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }

            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                //With the Above X-Pixel coordinate and Y-Pixel coordinate we can calculate the Width and Height 
                // calculate the transformed element pixel coordinates.
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                // Apply translation based on the change in origin.
                Content.TranslationX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                Content.TranslationY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                // Apply scale factor.
                Content.Scale = currentScale;
            }

            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation delta's of the wrapped user interface element.
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }
        public void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (Content.Scale == 1)
            {
                return;
            }

            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.

                    double newX = (e.TotalX * Scale) + xOffset;
                    double newY = (e.TotalY * Scale) + yOffset;

                    double width = (Content.Width * Content.Scale);
                    double height = (Content.Height * Content.Scale);

                    bool canMoveX = width > App.MainPageScreenWidth;
                    bool canMoveY = height > App.MainPageScreenHeight;

                    // In the Below Code we r Pinching  the Image for the Particular Corner with MoveX and MoveY  interface    element bounds.

                    if (canMoveX)
                    {
                        double minX = (width - (App.MainPageScreenWidth / 2)) * -1;
                        double maxX = Math.Min(App.MainPageScreenWidth / 2, width / 2);

                        if (newX < minX)
                        {
                            newX = minX;
                        }

                        if (newX > maxX)
                        {
                            newX = maxX;
                        }
                    }
                    else
                    {
                        newX = 0;
                    }

                    if (canMoveY)
                    {
                        double minY = (height - (App.MainPageScreenHeight / 2)) * -1;
                        double maxY = Math.Min(App.MainPageScreenHeight / 2, height / 2);

                        if (newY < minY)
                        {
                            newY = minY;
                        }

                        if (newY > maxY)
                        {
                            newY = maxY;
                        }
                    }
                    else
                    {
                        newY = 0;
                    }

                    Content.TranslationX = newX;
                    Content.TranslationY = newY;
                    break;
                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    // here we r finally panning the particular image 
                    xOffset = Content.TranslationX;
                    yOffset = Content.TranslationY;
                    break;
            }
        }
    }
}
