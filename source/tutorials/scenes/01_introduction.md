---
_modificationDate: "10/20/2023"
---

# Scene Tutorial Introduction

In this tutorial series, we'll go over the concept of what a game **scene** is, what it means for our game, and how we can implement the idea in code.

We'll create a reusable class library that can be used with any of our game projects, then create a new MonoGame game project to test the implementations of our scenes.

Finally, we'll briefly touch into how you can add transitions between scenes to give cool effects like fade-in fade-out.


> [!NOTE]
> The method of implementing scenes here is just one of many.  I try to keep things simple for tutorials and give a foundation for readers to expand on with their own ideas.
>
> If you would like to see implementations of scene structures created by other members of the MonoGame community, I would suggest taking a look at the source code in [Nez](https://github.com/prime31/Nez/tree/master/Nez.Portable/ECS) by [prime31](https://github.com/prime31).

## Prerequisites
To follow along with this tutorial, you will need to be able to create a new MonoGame 3.8.1.303 game project.  If you do not have your environment setup for creating MonoGame project, please refer to the [official documentation](https://docs.monogame.net/articles/getting_started/0_getting_started.html) to get setup first.

## Project Files
You can find the completed version of the project created with this tutorial at

## Code License
All code written in this Scene Tutorial series, unless otherwise stated, is licensed under **The Unlicense**.  This license extends only to the code written, not the tutorial documentation itself.  The license text is as follows:

```txt
This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org/>
```

With that out of the way, let's jump to the next page of the tutorial to get started.
