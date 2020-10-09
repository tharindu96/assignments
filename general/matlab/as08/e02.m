function varargout = e02(varargin)
%E02 M-file for e02.fig
%      E02, by itself, creates a new E02 or raises the existing
%      singleton*.
%
%      H = E02 returns the handle to a new E02 or the handle to
%      the existing singleton*.
%
%      E02('Property','Value',...) creates a new E02 using the
%      given property value pairs. Unrecognized properties are passed via
%      varargin to e02_OpeningFcn.  This calling syntax produces a
%      warning when there is an existing singleton*.
%
%      E02('CALLBACK') and E02('CALLBACK',hObject,...) call the
%      local function named CALLBACK in E02.M with the given input
%      arguments.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help e02

% Last Modified by GUIDE v2.5 07-Dec-2017 22:08:04

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @e02_OpeningFcn, ...
                   'gui_OutputFcn',  @e02_OutputFcn, ...
                   'gui_LayoutFcn',  [], ...
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


% --- Executes just before e02 is made visible.
function e02_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   unrecognized PropertyName/PropertyValue pairs from the
%            command line (see VARARGIN)

% Choose default command line output for e02
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes e02 wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = e02_OutputFcn(hObject, eventdata, handles)
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes on button press in pb_findSqrt.
function pb_findSqrt_Callback(hObject, eventdata, handles)
% hObject    handle to pb_findSqrt (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

v = str2double(handles.e_value.String);
r = sqrt(v);
handles.txt_result.String = r;



function e_value_Callback(hObject, eventdata, handles)
% hObject    handle to e_value (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Hints: get(hObject,'String') returns contents of e_value as text
%        str2double(get(hObject,'String')) returns contents of e_value as a double


% --- Executes during object creation, after setting all properties.
function e_value_CreateFcn(hObject, eventdata, handles)
% hObject    handle to e_value (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    empty - handles not created until after all CreateFcns called

% Hint: edit controls usually have a white background on Windows.
%       See ISPC and COMPUTER.
if ispc && isequal(get(hObject,'BackgroundColor'), get(0,'defaultUicontrolBackgroundColor'))
    set(hObject,'BackgroundColor','white');
end
