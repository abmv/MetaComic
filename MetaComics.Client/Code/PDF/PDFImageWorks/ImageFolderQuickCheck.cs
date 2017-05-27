using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DevWilson
{
    internal class ImageFolderQuickCheck
    {
        public static void QuickCheck(ImageList images, string imagesFolder)
        {
            if (!string.IsNullOrEmpty(imagesFolder))
            {
                var sourceImageList =
                    new List<string>(Directory.GetFiles(imagesFolder, "*.jpg", SearchOption.AllDirectories));
                var removeIndex = new List<int>();
                // Verify image cache list
                //at this stage we only care about images that have been removed from the main images folder
                bool hasChanged = false;
                sourceImageList.Sort(StringComparer.OrdinalIgnoreCase);
                for (int i = 0; i < images.Count; i++)
                {
                    ImageFileAttributes imageAttributes = images[i];
                    int sourceIndex = sourceImageList.BinarySearch(imageAttributes.Path,
                                                                   StringComparer.OrdinalIgnoreCase);
                    if (sourceIndex < 0)
                    {
                        //image is not longer in main folder
                        removeIndex.Add(i);
                    }
                    else
                    {
                        //item exists, remove it from the initial list
                        sourceImageList.RemoveAt(sourceIndex);
                    }
                }
                //we must remove from the end of the images list backwards otherwise we screw the index positions
                removeIndex.Reverse();
                for (int i = 0; i < removeIndex.Count; i++)
                {
                    ImageFileAttributes imageAttributes = images[removeIndex[i]];
                    // Remove image from cache
                    hasChanged = true;
                    images.RemoveAt(removeIndex[i]);
                }
                //now add new images into the cache
                for (int i = 0; i < sourceImageList.Count; i++)
                {
                    string imagePath = sourceImageList[i];
                    // Add image to cache
                    hasChanged = true;
                    Size originalSize = ImageHeader.GetDimensions(imagePath);
                    images.Add(new ImageFileAttributes(imagePath, originalSize));
                }
                if (hasChanged)
                {
                    images.Save();
                }
            }
        }
    }
}