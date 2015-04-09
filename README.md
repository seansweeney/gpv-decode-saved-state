# GPV  Decode Saved State

## Introduction

This is an add-in for the [AppGeo General Purpose Viewer](https://github.com/AppGeo/GPV) designed to decode saved states from the [GPVSavedState table](https://github.com/AppGeo/GPV/wiki/GPVSavedState).  It creates a page that will prompt for the StateID, query the table for State, then present the encoded values in an easy to read format.  This can be useful when debugging a user's map issue.

## Installation

You can install the code with or without authentication.

### With authentication

Copy the two files to the Admin directory of your GPV installation.  When visiting the page you will be prompted for admin privileges before you can run the script.

### Without authentication

Copy the two files to the root directory of your GPV installation.  Anyone will be able to run the script.