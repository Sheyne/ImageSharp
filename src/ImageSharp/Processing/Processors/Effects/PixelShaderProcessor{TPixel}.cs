// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Numerics;

using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Processing.Processors.Effects
{
    /// <summary>
    /// Applies a user defined pixel shader effect through a given delegate.
    /// </summary>
    /// <typeparam name="TPixel">The pixel format.</typeparam>
    internal sealed class PixelShaderProcessor<TPixel> : PixelShaderProcessorBase<TPixel>
        where TPixel : struct, IPixel<TPixel>
    {
        /// <summary>
        /// The user defined pixel shader.
        /// </summary>
        private readonly PixelShader pixelShader;

        /// <summary>
        /// Initializes a new instance of the <see cref="PixelShaderProcessor{TPixel}"/> class.
        /// </summary>
        /// <param name="configuration">The configuration which allows altering default behaviour or extending the library.</param>
        /// <param name="definition">The <see cref="PixelShaderProcessor"/> defining the processor parameters.</param>
        /// <param name="source">The source <see cref="Image{TPixel}"/> for the current processor instance.</param>
        /// <param name="sourceRectangle">The source area to process for the current processor instance.</param>
        public PixelShaderProcessor(Configuration configuration, PixelShaderProcessor definition, Image<TPixel> source, Rectangle sourceRectangle)
            : base(configuration, definition.Modifiers, source, sourceRectangle)
        {
            this.pixelShader = definition.PixelShader;
        }

        /// <inheritdoc/>
        protected override void ApplyPixelShader(Span<Vector4> span, Point offset) => this.pixelShader(span);
    }
}
