function varargout = e04(varargin)
% E04 MATLAB code for e04.fig
%      E04, by itself, creates a new E04 or raises the existing
%      singleton*.
%
%      H = E04 returns the handle to a new E04 or the handle to
%      the existing singleton*.
%
%      E04('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in E04.M with the given input arguments.
%
%      E04('Property','Value',...) creates a new E04 or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before e04_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to e04_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help e04

% Last Modified by GUIDE v2.5 07-Dec-2017 22:48:02

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @e04_OpeningFcn, ...
                   'gui_OutputFcn',  @e04_OutputFcn, ...
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


% --- Executes just before e04 is made visible.
function e04_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to e04 (see VARARGIN)

% Choose default command line output for e04
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes e04 wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = e04_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;



function ed_function_Callback(hObject, eventdata, handles)
% hObject    handle to ed_function (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of ed_function as text
%        str2double(get(hObject,'String')) returns contents of ed_function as a double

handles.func = inline(get(hObject, 'String'), 'x');

guidata(hObject, handles);

myPlot(handles);



% --- Executes during object creation, after setting all properties.
function ed_function_CreateFcn(hObject, eventdata, handles)
% hObject    handle to ed_function (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end


% --- Executes on button press in ch_grid.
function ch_grid_Callback(hObject, eventdata, handles)
% hObject    handle to ch_grid (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hint: get(hObject,'Value') returns toggle state of ch_grid
axes(handles.ax_main);
if(get(hObject, 'Value') == true)
    grid on;
else
    grid off;
end


% --- Executes on selection change in po_color.
function po_color_Callback(hObject, eventdata, handles)
% hObject    handle to po_color (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: contents = cellstr(get(hObject,'String')) returns po_color contents as cell array
%        contents{get(hObject,'Value')} returns selected item from po_color

contents = cellstr(get(hObject,'String'));
color = contents{get(hObject,'Value')};
switch color
    case 'red'
        handles.color = 'r';
    case 'green'
        handles.color = 'g';
    case 'blue'
        handles.color = 'b';
end

guidata(hObject, handles);

myPlot(handles);

        


% --- Executes during object creation, after setting all properties.
function po_color_CreateFcn(hObject, eventdata, handles)
% hObject    handle to po_color (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: popupmenu controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end



function ed_min_Callback(hObject, eventdata, handles)
% hObject    handle to ed_min (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of ed_min as text
%        str2double(get(hObject,'String')) returns contents of ed_min as a double
s = get(hObject,'String');
if ~isreal(s)
    return;
end
handles.lm_min = str2double(s);

guidata(hObject, handles);

myPlot(handles);

% --- Executes during object creation, after setting all properties.
function ed_min_CreateFcn(hObject, eventdata, handles)
% hObject    handle to ed_min (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end



function ed_max_Callback(hObject, eventdata, handles)
% hObject    handle to ed_max (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of ed_max as text
%        str2double(get(hObject,'String')) returns contents of ed_max as a double
s = get(hObject,'String');
if ~isreal(s)
    return;
end
handles.lm_max = str2double(s);

guidata(hObject, handles);

myPlot(handles);


% --- Executes during object creation, after setting all properties.
function ed_max_CreateFcn(hObject, eventdata, handles)
% hObject    handle to ed_max (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end

function myPlot(handles)

if all(isfield(handles, {'func', 'color', 'lm_min', 'lm_max'})) == false
    return;
end

func = handles.func;
color = handles.color;
lm_min = handles.lm_min;
lm_max = handles.lm_max;
x = lm_min:0.1:lm_max;
y = real(func(x));
axes(handles.ax_main);
plot(x, y, 'Color', color);
