//-------------------------------------------------------------------------------------------------
// <copyright file="precomp.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
//    
//    The use and distribution terms for this software are covered by the
//    Common Public License 1.0 (http://opensource.org/licenses/cpl1.0.php)
//    which can be found in the file CPL.TXT at the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by
//    the terms of this license.
//    
//    You must not remove this notice, or any other, from this software.
// </copyright>
// 
//-------------------------------------------------------------------------------------------------
#pragma once

#include <windows.h>
#include <msiquery.h>
#include <wchar.h>

const WCHAR MAGIC_MULTISZ_DELIM = 128;

#include "wixstrsafe.h"
#include "wcautil.h"
#include "wcalog.h"
#include "wcawow64.h"
#include "wcawrapquery.h"
#include "wiutil.h"
#include "fileutil.h"
#include "memutil.h"
#include "strutil.h"
