using CommunityToolkit.Maui.Views;
using IncredibleFit.Screens;
using IncredibleFit.SQL;

namespace IncredibleFit.PopUps;

public partial class EditRecipeSearchFilterPopUp : Popup
{
    private string _filterKeyword;
    private string _filterIngredient;
	private RecipeSearch _rS;
    public EditRecipeSearchFilterPopUp(RecipeSearch rS, string filterKeyword, string filterIngredient)
    {
        this._filterKeyword = filterKeyword;
        this._filterIngredient = filterIngredient;
		this._rS = rS;

		InitializeComponent();
		AdjustVisibility();
	}

	private void AdjustVisibility()
	{
		if (_filterKeyword != "") 
		{
			KeywordFilter.IsVisible = false;
        }
		if (_filterIngredient != "")
		{
            IngredientFilter.IsVisible = false;
		}
	}

	void SearchClicked(object sender, EventArgs e)
	{
        _rS.adjustFilters(_filterKeyword, _filterIngredient);

        this.Close();
	}

	void KeywordEntryChanged(object sender, TextChangedEventArgs e)
	{
		_filterKeyword = e.NewTextValue;
	}

	void IngredientEntryChanged(object sender, TextChangedEventArgs e) 
	{ 
		_filterIngredient = e.NewTextValue;
	}
}