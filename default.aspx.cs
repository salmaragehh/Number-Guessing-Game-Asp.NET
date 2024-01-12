/*
* Filename: default.aspx.cs
* Project: Number Guessing Game
* By: Salma Rageh  
* Date: 2023-11-12
* Description: This file and it's functions correspond with the events that happen on the default.aspx page.
*/

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A04
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*  Name	:	userNameButton_Click()
	    *	Purpose :	when the user clicks the submit button, perform validation, create viewState variable, go to next page
        *	Inputs	:	object			         sender	        	    the oject
        *				EventArgs                e                      
	    *	Outputs	:	NONE
	    *	Returns	:	Nothing
	    */
        protected void userNameButton_Click(object sender, EventArgs e)
        {
            if (nameEmptyValid.IsValid && nameCharValid.IsValid)
            {
                ViewState["UserName"] = userNameBox.Text;
                Server.Transfer("MaxGuess.aspx");
            }
        }

        /*  Name	:	ReturnViewState()
	    *	Purpose :	to return the view state to use in other pages
        *	Inputs	:	None                    
	    *	Outputs	:	None
	    *	Returns	:	The view state
	    */
        public StateBag ReturnViewState()
        {
            return ViewState;
        }
    }
}