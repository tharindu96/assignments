function varargout = e03(varargin)
% E03 MATLAB code for e03.fig
%      E03, by itself, creates a new E03 or raises the existing
%      singleton*.
%
%      H = E03 returns the handle to a new E03 or the handle to
%      the existing singleton*.
%
%      E03('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in E03.M with the given input arguments.
%
%      E03('Property','Value',...) creates a new E03 or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before e03_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to e03_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help e03

% Last Modified by GUIDE v2.5 07-Dec-2017 22:34:12

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @e03_OpeningFcn, ...
                   'gui_OutputFcn',  @e03_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT


% --- Executes just before e03 is made visible.
function e03_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to e03 (see VARARGIN)

% Choose default command line output for e03
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes e03 wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = e03_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes during object creation, after setting all properties.
function ed_celsius_CreateFcn(hObject, eventdata, handles)
% hObject    handle to ed_celsius (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end



function ed_fahrenheit_Callback(hObject, eventdata, handles)
% hObject    handle to ed_fahrenheit (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of ed_fahrenheit as text
%        str2double(get(hObject,'String')) returns contents of ed_fahrenheit as a double
s = get(hObject, 'String');
if any(isreal(s)) == false
    return;
end
f = str2double(s);
c = fahrenheitToCelsius(f);
if c > 250 || c < -50
    return;
end
set(handles.sl_value, 'Value', c);
set(handles.ed_celsius, 'String', c);


% --- Executes during object creation, after setting all properties.
function ed_fahrenheit_CreateFcn(hObject, eventdata, handles)
% hObject    handle to ed_fahrenheit (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end


% --- Executes on slider movement.
function sl_value_Callback(hObject, eventdata, handles)
% hObject    handle to sl_value (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'Value') returns position of slider
%        get(hObject,'Min') and get(hObject,'Max') to determine range of slider

c = get(hObject, 'Value');
f = celsiusToFahrenheit(c);
handles.ed_celsius.String = c;
handles.ed_fahrenheit.String = f;


% --- Executes during object creation, after setting all properties.
function sl_value_CreateFcn(hObject, eventdata, handles)
% hObject    handle to sl_value (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: slider controls usually have a light gray background.
if isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor',[.9 .9 .9]);
end

function f = celsiusToFahrenheit(c)
    f = c * (9/5) + 32;
    
function c = fahrenheitToCelsius(f)
    c = (f - 32) * (5/9);


% --- Executes on key press with focus on ed_celsius and none of its controls.
function ed_celsius_KeyPressFcn(hObject, eventdata, handles)
% hObject    handle to ed_celsius (see GCBO)
% eventdata  structure with the following fields (see MATLAB.UI.CONTROL.UICONTROL)
%	Key: name of the key that was pressed, in lower case
%	Character: character interpretation of the key(s) that was pressed
%	Modifier: name(s) of the modifier key(s) (i.e., control, shift) pressed
% handles    structure with handles and user data (see GUIDATA)


% --- Executes on key press with focus on ed_celsius and none of its controls.
function ed_celsius_Callback(hObject, eventdata, handles)
s = get(hObject, 'String');
if any(isreal(s)) == false
    return;
end
c = str2double(s);
if c > 250 || c < -50
    return;
end
set(handles.sl_value, 'Value', c);
f = celsiusToFahrenheit(c);
set(handles.ed_fahrenheit, 'String', f);


% --- If Enable == 'on', executes on mouse press in 5 pixel border.
% --- Otherwise, executes on mouse press in 5 pixel border or over ed_celsius.
function ed_celsius_ButtonDownFcn(hObject, eventdata, handles)
% hObject    handle to ed_celsius (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
