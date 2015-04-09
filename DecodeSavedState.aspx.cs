using System;
using System.Data.OleDb;
using System.Text;

/// <summary>
/// Decode saved state
/// </summary>
public partial class DecodeSavedState: System.Web.UI.Page
{
    private AppState _appState;
    private Configuration _config = null;

    private void Page_Init(object sender, System.EventArgs e)
    {
        _config = AppContext.GetConfiguration();
    }
	
    public void Decode_Click(Object sender, EventArgs e)
	{
        StringBuilder htmlResult = new StringBuilder();

        RestoreState(txtStateID.Value);
        if (_appState != null) {
            htmlResult.Append("<b>Application:</b> " + _appState.Application + "<br />");
            htmlResult.Append("<b>Extent:</b> " + _appState.Extent + "<br />"); // AppContext.ExtentToString(_appState.Extent) + "<br />");
            htmlResult.Append("<b>Zoom Level:</b> " + _appState.Level + "<br />");
            htmlResult.Append("<b>Action:</b> " + _appState.Action.ToString() + "<br />");
            htmlResult.Append("<b>Active Data ID:</b> " + _appState.ActiveDataId + "<br />");
            htmlResult.Append("<b>Active Function Tab:</b> " + _appState.ActiveFunctionTab.ToString() + "<br />");
            htmlResult.Append("<b>Active Map ID:</b> " + _appState.ActiveMapId + "<br />");
            htmlResult.Append("<b>Data Tab:</b> " + _appState.DataTab + "<br />");
            htmlResult.Append("<b>Map Tab:</b> " + _appState.MapTab + "<br />");
            htmlResult.Append("<b>Markup Category:</b> " + _appState.MarkupCategory + "<br />");
            htmlResult.Append("<b>Markup Groups:</b> " + _appState.MarkupGroups.ToString() + "<br />");
            htmlResult.Append("<b>Proximity:</b> " + _appState.Proximity + "<br />");
            htmlResult.Append("<b>Query:</b> " + _appState.Query + "<br />");
            htmlResult.Append("<b>Selection Layer:</b> " + _appState.SelectionLayer + "<br />");
            htmlResult.Append("<b>Selection IDs:</b> " + _appState.SelectionIds.ToString() + "<br />");
            htmlResult.Append("<b>Target Layer:</b> " + _appState.TargetLayer + "<br />");
            String[] targetIdArr = new String[_appState.TargetIds.Count];
            _appState.TargetIds.CopyTo(targetIdArr, 0);
            String targetIdStr = string.Join(",", targetIdArr);
            htmlResult.Append("<b>Target IDs (" + _appState.TargetIds.Count.ToString() + "):</b> " + targetIdStr + "<br />");
            htmlResult.Append("<b>Function Tabs:</b> " + _appState.FunctionTabs.ToString("d") + "<br />");
            htmlResult.Append("<b>Active Function Tab:</b> " + _appState.ActiveFunctionTab.ToString("d") + "<br />");
            htmlResult.Append("<b>Coordinate Labels:</b> " + _appState.CoordinateLabels.ToString() + "<br />");
            //htmlResult.Append("<br />" + "<br />" + "<br />");
            //htmlResult.Append(_appState.ToString());

            divResult.InnerHtml = htmlResult.ToString();
        }
	}

    private void RestoreState(string state)
    {
        if (state.Length == 12)
        {
            string id = state;

            OleDbConnection connection = AppContext.GetDatabaseConnection();

            string sql = "select State from " + AppSettings.ConfigurationTablePrefix + @"SavedState 
    					where StateID = ?";
            OleDbCommand command = new OleDbCommand(sql, connection);
            command.Parameters.Add("@1", OleDbType.VarWChar).Value = id;

            state = command.ExecuteScalar() as string;

            connection.Close();

            if (state == null)
            {
                ShowError("The map you specified does not exist or is no longer available");
            }
            else
            {
                _appState = AppState.FromCompressedString(state);
            }
        }
    }

    private void ShowError(string message)
    {
        Session["StartError"] = message;
        Server.Transfer("StartViewer.aspx");
    }
}
