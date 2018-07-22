# BloggerToHugo
A simple console app for converting Blogger exported xml file to Hugo html files.

This program is based on Alan Tsai's [mhat-consoleapp-blogger_to_wyam](https://github.com/alantsai/mhat-consoleapp-blogger_to_wyam), which is for Wyam. Many thanks to Alan Tsai!

## Usage

Rather than simply compile and run this console app, please clone or download the source code and follow instructions below:

1. Modify Constanst.cs for your needs.
2. Build the project.
3. Export posts from your Google Blogger site, rename it from "blog-yyyy-mm-dd.xml" to "blog.xml" and copy it to the project output directory, e.g. `bin\Debug\net452`.
4. Run the application and see if there are html files generated under sub-directory "post." You might need to edit "categories" and "tags" property for each html file.
5. Copy the generated html files to your Hugo web site's content\post\ directory. Done.

*Note:* 

- If you didn't rename your xml file to "blog.xml" (step 3), you'll need to add command line arguments when you run this application.
- My blog posts are using images from Google Drive, so I don't need to download images files, and I simply commented those code. 
