function varargout = e01(varargin)
% E01 MATLAB code for e01.fig
%      E01, by itself, creates a new E01 or raises the existing
%      singleton*.
%
%      H = E01 returns the handle to a new E01 or the handle to
%      the existing singleton*.
%
%      E01('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in E01.M with the given input arguments.
%
%      E01('Property','Value',...) creates a new E01 or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before e01_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to e01_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help e01

% Last Modified by GUIDE v2.5 07-Dec-2017 21:53:24

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @e01_OpeningFcn, ...
                   'gui_OutputFcn',  @e01_OutputFcn, ...
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


% --- Executes just before e01 is made visible.
function e01_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to e01 (see VARARGIN)

% Choose default command line output for e01
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes e01 wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = e01_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes on button press in pb_launchMessage.
function pb_launchMessage_Callback(hObject, eventdata, handles)
% hObject    handle to pb_launchMessage (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
handles.txt_message.String = 'Hello World!!';


% --- Executes on button press in pb_clearMessage.
function pb_clearMessage_Callback(hObject, eventdata, handles)
% hObject    handle to pb_clearMessage (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
handles.txt_message.String = '';
