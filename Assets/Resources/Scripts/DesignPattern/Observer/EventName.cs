using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventName
{
    public static class GamePlay
    {
        /// <summary>
        /// S? ki?n b?t �?u play instruction
        /// </summary>
        public const string INSTRUCTION_BEGIN = "GamePlay.INSTRUCTION_BEGIN";

        /// <summary>
        /// S? ki�n sau khi ho�n th�nh instruction
        /// </summary>
        public const string INSTRUCTION_END = "GamePlay.INSTRUCTION_END";

        /// <summary>
        /// S? ki?n d?ng instruction t? ng�?i d�ng
        /// </summary>
        public const string INSTRUCTION_STOP = "GamePlay.INSTRUCTION_STOP";

        /// <summary>
        /// S? ki?n vu?t �?n trang cu?i
        /// </summary>
        public const string END_PAGE = "GamePlay.END_PAGE";
        /// <summary>
        /// S? ki?n vu?t �?n trang ti?p theo
        /// </summary>
        public const string NEXT_PAGE = "GamePlay.NEXT_PAGE";
        /// <summary>
        /// S? ki?n vu?t �?n trang tr�?c ��
        /// </summary>
        public const string PREVIOUS_PAGE = "GamePlay.PREVIOUS_PAGE";
        /// <summary>
        /// S? ki?n vu?t �?n trang tr�?c ��
        /// </summary>
        public const string POINTER_DOWN = "GamePlay.POINTER_DOWN";
        /// <summary>
        /// S? ki?n vu?t �?n trang tr�?c ��
        /// </summary>
        public const string POINTER_UP = "GamePlay.POINTER_UP";

        /// <summary>
        /// S? ki?n b?t �?u load game play c?a l�?t ch�i
        /// </summary>
        public const string GAME_PLAY_LOAD = "GamePlay.GAME_PLAY_LOAD";

        /// <summary>
        /// S? ki?n b?t �?u load game play c?a l�?t ch�i
        /// </summary>
        public const string GAME_PLAY_SEND_DATA = "GamePlay.GAME_PLAY_SEND_DATA";

        /// <summary>
        /// S? ki?n load xong game play c?a l�?t ch�i
        /// </summary>
        public const string GAME_PLAY_LOADED = "GamePlay.GAME_PLAY_LOADED";

        /// <summary>
        /// S? ki?n game play b?t �?u ch?y logic
        /// </summary>
        public const string GAME_PLAY_BEGIN = "GamePlay.GAME_PLAY_BEGIN";

        /// <summary>
        /// S? ki?n k?t th�c game play
        /// </summary>
        public const string GAME_PLAY_END = "GamePlay.GAME_PLAY_END";

        /// <summary>
        /// S? ki?n k?t th�c QUIT_LESSON
        /// </summary>
        public const string QUIT_LESSON = "GamePlay.QUIT_LESSON";

        /// <summary>
        /// S? ki?n k?t th�c QUIT_LESSON
        /// </summary>
        public const string QUESTION_SHOWED = "GamePlay.QUESTION_SHOWED";


       


        /// <summary>
        /// S? ki?n �i theo m?t v?t th?
        /// </summary>
        public const string FOLLOW = "GamePlay.FOLLOW";

        /// <summary>
        /// S? ki?n sync item t?i � tr?ng
        /// </summary>
        public const string SYNC_TEXT_EMPTY_BLOCK_START = "GamePlay.SYNC_TEXT_EMPTY_BLOCK_START";

        /// <summary>
        /// S? ki?n ho�n th�nh sync item t?i � tr�ng
        /// </summary>
        public const string SYNC_TEXT_EMPTY_BLOCK_END = "GamePlay.SYNC_TEXT_EMPTY_BLOCK_END";

        public const string ACTION_DONE = "GamePlay.ACTION_DONE";

        public const string NEXT_TURN = "GamePlay.NEXT_TURN";

        public const string YOUR_TURN = "GamePlay.YOUR_TURN";
        public const string CORRECT_ANSWER = "GamePlay.CORRECT_ANSWER";
        public const string AFTER_CORRECT_ANSWER = "GamePlay.AFTER_CORRECT_ANSWER";
        public const string CORRECT_ALL = "GamePlay.CORRECT_ALL";




        /// <summary>
        /// S? ki?n b?t �?u play instruction
        /// </summary>
        public const string SYNCTEXT_BEGIN = "GamePlay.SYNCTEXT_BEGIN";

        /// <summary>
        /// S? ki�n sau khi ho�n th�nh instruction
        /// </summary>
        public const string SYNCTEXT_END = "GamePlay.SYNCTEXT_END";

        /// <summary>
        /// S? ki?n d?ng instruction t? ng�?i d�ng
        /// </summary>
        public const string SYNCTEXT_STOP = "GamePlay.SYNCTEXT_STOP";

        /// <summary>
        /// S? ki?n d?ng instruction t? ng�?i d�ng
        /// </summary>
        public const string SYNCTEXT_ITEM_END = "GamePlay.SYNCTEXT_ITEM_END";

        /// <summary>
        /// S? ki?n sau khi xong anim c?a ch? 
        /// </summary>
        public const string DONE_TEXT_ANIM = "GamePlay.DONE_TEXT_ANIM";

        /// <summary>
        /// S? ki?n b?t �?u anim c?a ch?
        /// </summary>
        public const string START_TEXT_ANIM = "GamePlay.START_TEXT_ANIM";

        /// <summary>
        /// S? ki?n review �?c item c?a ng�?i d�ng
        /// </summary>
        public const string ITEM_REVIEW = "GamePlay.ITEM_REVIEW";

        /// <summary>
        /// S? ki?n m?t item ��?c �?p
        /// </summary>
        public const string ITEM_SMASHED = "GamePlay.ITEM_SMASHED";

        /// <summary>
        /// S? ki?n c�c item ho�n th�nh vi?c xu?t hi?n
        /// </summary>
        public const string ITEM_DONE_APPEAR = "GamePlay.ITEM_DONE_APPEAR";

        /// <summary>
        /// S? ki?n �?p g?ch ho�n th�nh
        /// </summary>
        public const string SMASH_DONE = "GamePlay.SMASH_DONE";

        /// <summary>
        /// S? ki?n disable touch
        /// </summary>
        public const string DISABLE_TOUCH = "GamePlay.DISABLE_TOUCH";

        /// <summary>
        /// S? ki?n enable touch
        /// </summary>
        public const string ENABLE_TOUCH = "GamePlay.ENABLE_TOUCH";

        /// <summary>
        /// S? ki?n ho�n th�nh intro
        /// </summary>
        public const string INTRO_DONE = "GamePlay.INTRO_DONE";

        /// <summary>
        /// S? ki?n ho�n th�nh outtro
        /// </summary>
        public const string OUTTRO_DONE = "GamePlay.OUTRO_DONE";

        /// <summary>
        /// Su kien thay doi layer cua khi
        /// </summary>
        public const string CHANGE_LAYER = "GamePlay.CHANGE_LAYER";

        /// <summary>
        /// S? ki?n item di chuy?n ho�n th�nh
        /// </summary>
        public const string DONE_MOVING = "GamePlay.DONE_MOVING";

        /// <summary>
        /// S? ki?n kh? h?nh ph�c
        /// </summary>
        public const string MONKEY_HAPPY = "GamePlay.MONKEY_HAPPY";

        /// <summary>
        /// S? ki?n hi?n th? n�t k?t th�c game
        /// </summary>
        public const string BUTTON_END_GAME_APPEAR = "GamePlay.BUTTON_END_GAME_APPEAR";

        /// <summary>
        /// S? ki?n ho�n th�nh scroll
        /// </summary>
        public const string SCROLL_END = "GamePlay.SCROLL_END";

        public const string START_GAME_PLAY = "GamePlay.START_GAME_PLAY";


        public const string AUDIO_BEGIN = "GamePlay.AUDIO_BEGIN";
        public const string AUDIO_STOP = "GamePlay.AUDIO_STOP";

        public const string ANSWER_RIGHT = "GamePlay.ANSWER_RIGHT";
        public const string ANSWER_WRONG = "GamePlay.ANSWER_WRONG";

        /// <summary>
        /// S? ki?n khi load xong data
        /// </summary>
        public const string LOAD_DATA_DONE = "GamePlay.LOAD_DATA_DONE";

        /// <summary>
        /// S? ki?n khi sync xong duwx lieeuj
        /// </summary>
        public const string SYNC_DONE = "GamePlay.SYNC_DONE";

        /// <summary>
        /// S? ki?n khi load xong ��p �n
        /// </summary>
        public const string ANSWER_SHOW_DONE = "GamePlay.ANSWER_SHOW_DONE";


        //======================================================================================
        /// <summary>
        /// Su kien khi click vao game item
        /// </summary>
        public const string ITEM_CLICK = "GamePlay.ITEM_CLICK";

        public const string ITEM_UNCLICK = "GamePlay.ITEM_UNCLICK";

        public const string ITEM_TAP = "GamePlay.ITEM_TAP";

        public const string ITEM_PRESS = "GamePlay.ITEM_PRESS";

        public const string ITEM_UNPRESS = "GamePlay.ITEM_UNPRESS";

        /// <summary>
        /// Su kien khi click vao button
        /// </summary>
        public const string BUTTON_CLICK = "GamePlay.Button_Click";
    }

    public static class AccessPermission
    {
        /// <summary>
        /// S? ki?n sau khi y�u c?u truy c?p camera 
        /// </summary>
        public const string ACCESS_CAMERA = "UsagePermission.ACCESS_CAMERA";

        /// <summary>
        /// S? ki?n sau khi y�u c?u truy c?p micro
        /// </summary>
        public const string ACCESS_MICRO = "UsagePermission.ACCESS_MICRO";

        /// <summary>
        /// S? ki?n sau khi y�u c?u truy c?p gallery
        /// </summary>
        public const string ACCESS_GALLERY = "UsagePermission.ACCESS_GALLERY";
    }

    public static class GameState
    {
        /// <summary>
        /// Su kien khi load data
        /// </summary>
        public const string GAME_LOAD = "GameState.GAME_LOAD";

        /// <summary>
        /// S� ki?n khi Open Game
        /// </summary>
        public const string GAME_START_OPEN = "GameState.START_OPEN";
        /// <summary>
        /// S� ki?n khi Init Data
        /// </summary>
        public const string GAME_INITED = "GameState.GAME_INITED";
        /// <summary>
        /// S� ki?n khi b?t �?u game 
        /// </summary>
        public const string GAME_START = "GameState.GAME_START";

        /// <summary>
        /// S? ki?n khi k?t th�c game
        /// </summary>
        public const string GAME_END = "GameState.GAME_END";


        /// <summary>
        /// S? ki?n khi bu?c k?t th�c game
        /// </summary>
        public const string GAME_STOP = "GameState.GAME_STOP";


        /// <summary>
        /// S? ki?n khi b?t �?u game state: intro, play, ending 
        /// </summary>
        public const string STATE_BEGAN = "GameState.STATE_BEGAN";

        /// <summary>
        /// S? ki?n khi k?t th�c game state: intro, play, ending 
        /// </summary>
        public const string STATE_END = "GameState.STATE_END";
        /// <summary>
        /// S? ki?n khi k?t th�c game
        /// </summary>
        public const string FINISH_LESSON = "GameState.FINISH_LESSON";
        /// <summary>
        /// S? ki?n khi k?t th�c game
        /// </summary>
        public const string QUIT_GAME = "GameState.GameQuit";

        //s? ki?n khi �ang h?c d? nh?n X tho�t ra
        public const string EXIT_GAME_PLAYING = "GameState.ExitGamePlaying";

        //s? ki?n khi Nh?n xong h?p qu�
        public const string CALL_TO_GET_REWARD = "GameState.CallToNextPage";

        //s? ki?n cheat lesson
        public const string CHEAT_LESSON = "GameState.CHEAT_LESSON";

        /// <summary>
        /// Su kien khi lua chon xong nhan vat
        /// </summary>
        public const string SELECTED_CHARACTER = "GameState.Selected_Character";
    }

    

 
}


