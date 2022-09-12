﻿namespace MooseEngine.Graphics.UI.Options;

public class SliderOptions : TextOptions
{
	private readonly static Color DEFAULT_SLIDER_COLOR = new Color(151, 232, 255, 255);
    private readonly static int DEFAULT_TEXT_PADDING = 2;

    //public SliderOptions(bool interactable = true)
    //	: this(UIScreenCoords.Zero, UIScreenCoords.One, 24, string.Empty, TextAlignment.None, 0, 100, DEFAULT_SLIDER_COLOR, DEFAULT_BACKGROUND_COLOR, 
    //		  DEFAULT_BORDER_NORMAL_COLOR, DEFAULT_BORDER_FOCUSED_COLOR, DEFAULT_BORDER_PRESSED_COLOR, DEFAULT_BORDER_DISABLED_COLOR, interactable)
    //   {
    //}

    //public SliderOptions(UIScreenCoords position, UIScreenCoords size, int fontSize, string text, TextAlignment textAlignment, int minValue, int maxValue, bool interactable = true)
    //	: this(position, size, fontSize, text, textAlignment, minValue, maxValue, DEFAULT_SLIDER_COLOR, DEFAULT_BACKGROUND_COLOR, 
    //		  DEFAULT_BORDER_NORMAL_COLOR, DEFAULT_BORDER_FOCUSED_COLOR, DEFAULT_BORDER_PRESSED_COLOR, DEFAULT_BORDER_DISABLED_COLOR, interactable)
    //{
    //}

    //public SliderOptions(UIScreenCoords position, UIScreenCoords size, int fontSize, string text, TextAlignment textAlignment, int minValue, int maxValue, Color color, Color backgroundColor, bool interactable = true)
    //	: base(position, size, text, fontSize, interactable)
    //{
    //	TextAlignment = textAlignment;
    //	BorderWidth = 0;
    //	Padding = 1;
    //	TextPadding = 2;

    //	MaxValue = maxValue;
    //	MinValue = minValue;
    //	SliderColor = color;
    //}

    public SliderOptions(UIScreenCoords position, UIScreenCoords size, string text, int fontSize, TextAlignment textAlignment, int minValue, int maxValue, bool interactable = true)
        : this(position, size, text, fontSize, textAlignment, DEFAULT_BACKGROUND_COLOR, DEFAULT_NORMAL_COLOR, minValue, maxValue, interactable)
    {
    }

    public SliderOptions(UIScreenCoords position, UIScreenCoords size, string text, int fontSize, TextAlignment textAlignment, Color backgroundColor, Color sliderColor, int minValue, int maxValue, bool interactable = true)
        : this(position, size, text, fontSize, DEFAULT_BORDER_WIDTH, textAlignment, DEFAULT_BACKGROUND_COLOR, DEFAULT_TEXT_NORMAL_COLOR, DEFAULT_NORMAL_COLOR, minValue, maxValue, interactable)
    {
    }

    public SliderOptions(UIScreenCoords position, UIScreenCoords size, string text, int fontSize, int borderWidth, TextAlignment textAlignment, Color backgroundColor, Color textColor, Color sliderColor, int minValue, int maxValue, bool interactable = true)
    : this(position, size, text, fontSize, DEFAULT_TEXT_SPACING, borderWidth, DEFAULT_PADDING, textAlignment,
          DEFAULT_LINE_COLOR, backgroundColor,
          sliderColor, DEFAULT_FOCUSED_COLOR, DEFAULT_PRESSED_COLOR, DEFAULT_DISABLED_COLOR,
          textColor, DEFAULT_TEXT_FOCUSED_COLOR, DEFAULT_TEXT_PRESSED_COLOR, DEFAULT_TEXT_DISABLED_COLOR,
          DEFAULT_BORDER_NORMAL_COLOR, DEFAULT_BORDER_FOCUSED_COLOR, DEFAULT_BORDER_PRESSED_COLOR, DEFAULT_BORDER_DISABLED_COLOR,
          DEFAULT_TEXT_PADDING, maxValue, minValue, interactable)
    {
    }

    public SliderOptions(UIScreenCoords position, UIScreenCoords size, string text, int fontSize, float textSpacing, int borderWidth, int padding, TextAlignment textAlignment,
		Color lineColor, Color backgroundColor, 
		Color normalColor, Color focusedColor, Color pressedColor, Color disabledColor,
		Color textNormalColor, Color textFocusedColor, Color textPressedColor, Color textDisabledColor,
		Color borderNormalColor, Color borderFocusedColor, Color borderPressedColor, Color borderDisabledColor,
		int textPadding, int maxValue, int minValue, bool interactable)
		: base(position, size, text, fontSize, textSpacing, borderWidth, padding, textAlignment, 
			lineColor, backgroundColor,
			normalColor, focusedColor, pressedColor, disabledColor, 
			textNormalColor, textFocusedColor, textPressedColor, textDisabledColor, 
			borderNormalColor, borderFocusedColor, borderPressedColor, borderDisabledColor, interactable)
    {
		TextPadding = textPadding;
		MaxValue = maxValue;
		MinValue = minValue;
    }

    public int TextPadding { get; set; }
    public int MaxValue { get; set; }
    public int MinValue { get; set; }
}

[Obsolete]
public class SliderOptionsDep
{
	public int BorderWidth { get; set; }
	public int Padding { get; set; }
	public int Width { get; set; }
	public int TextPadding { get; set; }

	public SliderOptionsDep()
	{
		BorderWidth = 0;
		Padding = 1;
		Width = 1;
		TextPadding = 2;
	}
}
