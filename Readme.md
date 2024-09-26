Metadara remover in C#

You can remove metadata from a file using this code. It is a simple code that removes metadata from an image file. 

Dependencies:

- Magick.NET-Q16-AnyCPU

You can install it using NuGet Package Manager.

```bash
Install-Package Magick.NET-Q16-AnyCPU
```
Code:

```csharp
using (MagickImage cleanImage = new MagickImage(imagePath))
            {          //save orientation if have in metadata
                var orientation = cleanImage.GetAttribute("EXIF:Orientation");
                if (orientation != null)
                {
                    cleanImage.AutoOrient();
                }
                cleanImage.Strip(); // Remove all metadata
                string cleanImagePath = Path.Combine(Path.GetDirectoryName(imagePath), "clean_" + Path.GetFileName(imagePath));
                cleanImage.Write(cleanImagePath);
            }
```
	