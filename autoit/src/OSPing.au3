#include <GUIConstantsEx.au3>
#include <GuiListView.au3>

Const $HIGHEST_WORLD = 94

Func Main()
	$hGUI = GUICreate("OSPing", 200, 300)

	$list = GUICtrlCreateListView("World|Ping", 0,0, 200,275)
	$button = GUICtrlCreateButton("Refresh",0,275)

	GUICtrlCreateListViewItem("a|b", $list)

	GUISetState(@SW_SHOW, $hGUI)

	_GUICtrlListView_RegisterSortCallBack($list)

	While 1
		Switch GUIGetMsg()
			Case $GUI_EVENT_CLOSE
				ExitLoop
			Case $button
				_GUICtrlListView_DeleteAllItems($list)
				For $i = 1 To $HIGHEST_WORLD
					$ping = Ping("oldschool" & $i & ".runescape.com", 1000)
					If $ping > 0 Then
						GUICtrlCreateListViewItem( $i & "|" & $ping & " ms", $list)
					EndIf
				Next
			Case $list
				_GUICtrlListView_SortItems($list, GUICtrlGetState($list))
		EndSwitch
	WEnd

	_GUICtrlListView_UnRegisterSortCallBack($list)
	GUIDelete($hGUI)
EndFunc

Main()