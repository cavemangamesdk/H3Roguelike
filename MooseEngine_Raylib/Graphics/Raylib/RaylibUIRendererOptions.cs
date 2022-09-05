﻿using MooseEngine.Graphics.UI.Options;
using System.Drawing;

namespace MooseEngine.Graphics;

public enum TextAlignment : uint
{
    Left = 0,
    Center,
    Right,
}

public enum ScrollbarSide
{
    Left,
    Right
}

public interface IRaylibUIRendererOptions
{
    int FontSize { get; set; }

    int BorderWidth { get; set; }
    int TextPadding { get; set; }
    float TextSpacing { get; set; }

    int ComboButtonWidth { get; set; }
    int ComboButtonSpacing { get; set; }

    ColorOptions Colors { get; set; }
    ButtonOptions ButtonOptions { get; set; }
    ListViewOptions ListViewOptions { get; set; }
    ScrollbarOptions ScrollbarOptions { get; set; }
    SliderOptions SliderOptions { get; set; }

    TextAlignment LabelTextAlignment { get; set; }
    TextAlignment StatusBarTextAlignment { get; set; }
}

internal class RaylibUIRendererOptions : IRaylibUIRendererOptions
{
    public int FontSize { get; set; }

    public int BorderWidth { get; set; }
    public int TextPadding { get; set; }
    public float TextSpacing { get; set; }

    public int ComboButtonWidth { get; set; }
    public int ComboButtonSpacing { get; set; }

    public ColorOptions Colors { get; set; }
    public ButtonOptions ButtonOptions { get; set; }
    public ListViewOptions ListViewOptions { get; set; }
    public ScrollbarOptions ScrollbarOptions { get; set; }
    public SliderOptions SliderOptions { get; set; }

    public TextAlignment StatusBarTextAlignment { get; set; }
    public TextAlignment LabelTextAlignment { get; set; }

    public RaylibUIRendererOptions(int fontSize)
    {
        FontSize = fontSize;

        BorderWidth = 1;
        TextPadding = 4;
        TextSpacing = 1;

        ComboButtonWidth = 32;
        ComboButtonSpacing = 2;

        Colors = new ColorOptions();
        ButtonOptions = new ButtonOptions();
        ListViewOptions = new ListViewOptions();
        ScrollbarOptions = new ScrollbarOptions();
        SliderOptions = new SliderOptions();

        StatusBarTextAlignment = TextAlignment.Left;
        LabelTextAlignment = TextAlignment.Left;
    }
}

