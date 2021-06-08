Imports System.IO
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq





Public Class Main
    Dim config_folder As String = "C:\Users\" & Environment.UserName & "\AppData\Roaming\PatrikPlotter"
    Dim log_folder As String = config_folder & "\logs\"
    Dim daemon_dir As String
    Dim default_daemon_dir As String = "C:/Users/" & Environment.UserName & "/AppData/Local/chia-blockchain/app-1.1.6/resources/app.asar.unpacked/daemon"
    Dim app_version As String = "V0.0.1"

    Dim timer_timer_start_delay As Double
    Dim timer_timer_start_count As Double


    Dim key_farmer As String = ""
    Dim key_pool As String
    Dim extra_keys As String

    'SSD drives ---------------------------------------------------------------------------------------
    Dim ssd_1_letter As String
    Dim ssd_1_name As String
    Dim ssd_1_plot_threads As Double
    Dim ssd_1_plot_memory As Double
    Dim ssd_1_plot_type As String
    Dim ssd_1_plot_ssd As String
    Dim ssd_1_plot_hdd As String
    Dim ssd_1_max_concurrent_plots As Double
    Dim ssd_1_plots_to_do As Double
    Dim ssd_1_plots_done As Double
    Dim ssd_1_plots_running As Double
    Dim ssd_1_plots_started As Double
    Dim ssd_1_timer_delay As Double
    Dim ssd_1_timer_count As Double
    Dim ssd_1_first_plot As Boolean = True
    Dim ssd_1_color As Color = Color.FromArgb(255, 255, 255)

    Dim ssd_2_letter As String
    Dim ssd_2_name As String
    Dim ssd_2_plot_threads As Double
    Dim ssd_2_plot_memory As Double
    Dim ssd_2_plot_type As String
    Dim ssd_2_plot_ssd As String
    Dim ssd_2_plot_hdd As String
    Dim ssd_2_max_concurrent_plots As Double
    Dim ssd_2_plots_to_do As Double
    Dim ssd_2_plots_done As Double
    Dim ssd_2_plots_running As Double
    Dim ssd_2_plots_started As Double
    Dim ssd_2_timer_delay As Double
    Dim ssd_2_timer_count As Double
    Dim ssd_2_first_plot As Boolean = True
    Dim ssd_2_color As Color = Color.FromArgb(255, 255, 255)

    Dim ssd_3_letter As String
    Dim ssd_3_name As String
    Dim ssd_3_plot_threads As Double
    Dim ssd_3_plot_memory As Double
    Dim ssd_3_plot_type As String
    Dim ssd_3_plot_ssd As String
    Dim ssd_3_plot_hdd As String
    Dim ssd_3_max_concurrent_plots As Double
    Dim ssd_3_plots_to_do As Double
    Dim ssd_3_plots_done As Double
    Dim ssd_3_plots_running As Double
    Dim ssd_3_plots_started As Double
    Dim ssd_3_timer_delay As Double
    Dim ssd_3_timer_count As Double
    Dim ssd_3_first_plot As Boolean = True
    Dim ssd_3_color As Color = Color.FromArgb(255, 255, 255)

    Dim ssd_4_letter As String
    Dim ssd_4_name As String
    Dim ssd_4_plot_threads As Double
    Dim ssd_4_plot_memory As Double
    Dim ssd_4_plot_type As String
    Dim ssd_4_plot_ssd As String
    Dim ssd_4_plot_hdd As String
    Dim ssd_4_max_concurrent_plots As Double
    Dim ssd_4_plots_to_do As Double
    Dim ssd_4_plots_done As Double
    Dim ssd_4_plots_running As Double
    Dim ssd_4_plots_started As Double
    Dim ssd_4_timer_delay As Double
    Dim ssd_4_timer_count As Double
    Dim ssd_4_first_plot As Boolean = True
    Dim ssd_4_color As Color = Color.FromArgb(255, 255, 255)

    Dim ssd_5_letter As String
    Dim ssd_5_name As String
    Dim ssd_5_plot_threads As Double
    Dim ssd_5_plot_memory As Double
    Dim ssd_5_plot_type As String
    Dim ssd_5_plot_ssd As String
    Dim ssd_5_plot_hdd As String
    Dim ssd_5_max_concurrent_plots As Double
    Dim ssd_5_plots_to_do As Double
    Dim ssd_5_plots_done As Double
    Dim ssd_5_plots_running As Double
    Dim ssd_5_plots_started As Double
    Dim ssd_5_timer_delay As Double
    Dim ssd_5_timer_count As Double
    Dim ssd_5_first_plot As Boolean = True
    Dim ssd_5_color As Color = Color.FromArgb(255, 255, 255)
    'SSD drives ---------------------------------------------------------------------------------------



    'Plot processes ----------------------------------------------------------------------------------------
    Dim plot_1_process As New Process
    Dim plot_1_process_running As Boolean = False
    Dim plot_1_process_logname As String = ""
    Dim plot_1_process_log As String = ""
    Dim plot_1_process_ssd As Double

    Dim plot_2_process As New Process
    Dim plot_2_process_running As Boolean = False
    Dim plot_2_process_logname As String = ""
    Dim plot_2_process_log As String = ""
    Dim plot_2_process_ssd As Double

    Dim plot_3_process As New Process
    Dim plot_3_process_running As Boolean = False
    Dim plot_3_process_logname As String = ""
    Dim plot_3_process_log As String = ""
    Dim plot_3_process_ssd As Double

    Dim plot_4_process As New Process
    Dim plot_4_process_running As Boolean = False
    Dim plot_4_process_logname As String = ""
    Dim plot_4_process_log As String = ""
    Dim plot_4_process_ssd As Double

    Dim plot_5_process As New Process
    Dim plot_5_process_running As Boolean = False
    Dim plot_5_process_logname As String = ""
    Dim plot_5_process_log As String = ""
    Dim plot_5_process_ssd As Double

    Dim plot_6_process As New Process
    Dim plot_6_process_running As Boolean = False
    Dim plot_6_process_logname As String = ""
    Dim plot_6_process_log As String = ""
    Dim plot_6_process_ssd As Double

    Dim plot_7_process As New Process
    Dim plot_7_process_running As Boolean = False
    Dim plot_7_process_logname As String = ""
    Dim plot_7_process_log As String = ""
    Dim plot_7_process_ssd As Double

    Dim plot_8_process As New Process
    Dim plot_8_process_running As Boolean = False
    Dim plot_8_process_logname As String = ""
    Dim plot_8_process_log As String = ""
    Dim plot_8_process_ssd As Double

    Dim plot_9_process As New Process
    Dim plot_9_process_running As Boolean = False
    Dim plot_9_process_logname As String = ""
    Dim plot_9_process_log As String = ""
    Dim plot_9_process_ssd As Double

    Dim plot_10_process As New Process
    Dim plot_10_process_running As Boolean = False
    Dim plot_10_process_logname As String = ""
    Dim plot_10_process_log As String = ""
    Dim plot_10_process_ssd As Double

    Dim plot_11_process As New Process
    Dim plot_11_process_running As Boolean = False
    Dim plot_11_process_logname As String = ""
    Dim plot_11_process_log As String = ""
    Dim plot_11_process_ssd As Double

    Dim plot_12_process As New Process
    Dim plot_12_process_running As Boolean = False
    Dim plot_12_process_logname As String = ""
    Dim plot_12_process_log As String = ""
    Dim plot_12_process_ssd As Double
    'Plot processes ----------------------------------------------------------------------------------------


    'Moving fix --------------------------------------------------------------------------------------------
    Const WM_NCHITTEST As Integer = &H84
    Const HTCLIENT As Integer = &H1
    Const HTCAPTION As Integer = &H2

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_NCHITTEST
                MyBase.WndProc(m)
                If m.Result = IntPtr.op_Explicit(HTCLIENT) Then m.Result = IntPtr.op_Explicit(HTCAPTION)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub
    '-------------------------------------------------------------------------------------------------------
    Dim Pos As Point
    Private Sub TabPage_plot_create_MouseMovee(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub
    Private Sub TabPage_plot_info_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Location += Control.MousePosition - Pos
        End If
        Pos = Control.MousePosition
    End Sub
    'Moving fix --------------------------------------------------------------------------------------------
    Private Sub btn_page_plot_create_Click(sender As Object, e As EventArgs) Handles btn_page_plot_create.Click
        TabControl_Pages.SelectedTab = TabPage_plot_create
    End Sub
    Private Sub btn_page_plot_Click(sender As Object, e As EventArgs) Handles btn_page_plot_info.Click
        TabControl_Pages.SelectedTab = TabPage_plot_info
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        progressbar_timer_1.Width = 0
        progressbar_timer_1_background.BackColor = Color.FromArgb(107, 112, 122)
        progressbar_timer_1.BackColor = Color.FromArgb(255, 255, 255)

        progressbar_timer_2.Width = 0
        progressbar_timer_2_background.BackColor = Color.FromArgb(107, 112, 122)
        progressbar_timer_2.BackColor = Color.FromArgb(255, 255, 255)

        progressbar_timer_3.Width = 0
        progressbar_timer_3_background.BackColor = Color.FromArgb(107, 112, 122)
        progressbar_timer_3.BackColor = Color.FromArgb(255, 255, 255)

        progressbar_timer_4.Width = 0
        progressbar_timer_4_background.BackColor = Color.FromArgb(107, 112, 122)
        progressbar_timer_4.BackColor = Color.FromArgb(255, 255, 255)

        progressbar_timer_5.Width = 0
        progressbar_timer_5_background.BackColor = Color.FromArgb(107, 112, 122)
        progressbar_timer_5.BackColor = Color.FromArgb(255, 255, 255)


        plot_1_progressbar.Width = 0
        plot_1_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_1_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_2_progressbar.Width = 0
        plot_2_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_2_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_3_progressbar.Width = 0
        plot_3_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_3_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_4_progressbar.Width = 0
        plot_4_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_4_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_5_progressbar.Width = 0
        plot_5_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_5_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_6_progressbar.Width = 0
        plot_6_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_6_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_7_progressbar.Width = 0
        plot_7_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_7_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_8_progressbar.Width = 0
        plot_8_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_8_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_9_progressbar.Width = 0
        plot_9_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_9_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_10_progressbar.Width = 0
        plot_10_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_10_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_11_progressbar.Width = 0
        plot_11_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_11_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        plot_12_progressbar.Width = 0
        plot_12_progressbar_background.BackColor = Color.FromArgb(107, 112, 122)
        plot_12_progressbar.BackColor = Color.FromArgb(255, 255, 255)

        label_timer_progress_1.Text = "? Min / ?Min (?%) | Time left: ? Min"
        label_timer_progress_2.Text = "? Min / ?Min (?%) | Time left: ? Min"
        label_timer_progress_3.Text = "? Min / ?Min (?%) | Time left: ? Min"
        label_timer_progress_4.Text = "? Min / ?Min (?%) | Time left: ? Min"
        label_timer_progress_5.Text = "? Min / ?Min (?%) | Time left: ? Min"

        label_patrik_plotter.Text = "Patrik Plotter" & vbNewLine & app_version

        timer_plot_progress.Start()

        If Not My.Computer.FileSystem.DirectoryExists(config_folder) Then
            My.Computer.FileSystem.CreateDirectory(config_folder)
        End If

        If Not My.Computer.FileSystem.DirectoryExists(log_folder) Then
            My.Computer.FileSystem.CreateDirectory(log_folder)
        End If

        If My.Computer.FileSystem.FileExists(config_folder & "\settings.json") Then
            read_settings_config()
        Else
            create_settings_config()
        End If
    End Sub


    Private Sub create_settings_config()
        Dim dataSet As DataSet = New DataSet("dataSet")
        dataSet.[Namespace] = "NetFrameWork"

        Dim data_table_keys As DataTable = New DataTable("keys")

        Dim data_table_config_daemon_dir As DataTable = New DataTable("config_daemon_dir")

        Dim data_table_ssd_1 As DataTable = New DataTable("ssd_1")
        Dim data_table_ssd_2 As DataTable = New DataTable("ssd_2")
        Dim data_table_ssd_3 As DataTable = New DataTable("ssd_3")
        Dim data_table_ssd_4 As DataTable = New DataTable("ssd_4")
        Dim data_table_ssd_5 As DataTable = New DataTable("ssd_5")

        Dim ssd_letter_1 As DataColumn = New DataColumn("ssd_letter")
        Dim ssd_letter_2 As DataColumn = New DataColumn("ssd_letter")
        Dim ssd_letter_3 As DataColumn = New DataColumn("ssd_letter")
        Dim ssd_letter_4 As DataColumn = New DataColumn("ssd_letter")
        Dim ssd_letter_5 As DataColumn = New DataColumn("ssd_letter")

        Dim ssd_name_1 As DataColumn = New DataColumn("ssd_name")
        Dim ssd_name_2 As DataColumn = New DataColumn("ssd_name")
        Dim ssd_name_3 As DataColumn = New DataColumn("ssd_name")
        Dim ssd_name_4 As DataColumn = New DataColumn("ssd_name")
        Dim ssd_name_5 As DataColumn = New DataColumn("ssd_name")

        Dim conifg_key_farmer As DataColumn = New DataColumn("farmer_public_key")
        Dim config_key_public As DataColumn = New DataColumn("pool_public_key")

        Dim config_daemon_dir As DataColumn = New DataColumn("daemon_dir")

        data_table_keys.Columns.Add(conifg_key_farmer)
        data_table_keys.Columns.Add(config_key_public)

        data_table_config_daemon_dir.Columns.Add(config_daemon_dir)

        data_table_ssd_1.Columns.Add(ssd_letter_1)
        data_table_ssd_2.Columns.Add(ssd_letter_2)
        data_table_ssd_3.Columns.Add(ssd_letter_3)
        data_table_ssd_4.Columns.Add(ssd_letter_4)
        data_table_ssd_5.Columns.Add(ssd_letter_5)

        data_table_ssd_1.Columns.Add(ssd_name_1)
        data_table_ssd_2.Columns.Add(ssd_name_2)
        data_table_ssd_3.Columns.Add(ssd_name_3)
        data_table_ssd_4.Columns.Add(ssd_name_4)
        data_table_ssd_5.Columns.Add(ssd_name_5)

        dataSet.Tables.Add(data_table_keys)
        dataSet.Tables.Add(data_table_config_daemon_dir)

        dataSet.Tables.Add(data_table_ssd_1)
        dataSet.Tables.Add(data_table_ssd_2)
        dataSet.Tables.Add(data_table_ssd_3)
        dataSet.Tables.Add(data_table_ssd_4)
        dataSet.Tables.Add(data_table_ssd_5)

        Dim newRow_1 As DataRow = data_table_ssd_1.NewRow()
        newRow_1("ssd_letter") = ""
        newRow_1("ssd_name") = ""
        data_table_ssd_1.Rows.Add(newRow_1)

        Dim newRow_2 As DataRow = data_table_ssd_2.NewRow()
        newRow_2("ssd_letter") = ""
        newRow_2("ssd_name") = ""
        data_table_ssd_2.Rows.Add(newRow_2)

        Dim newRow_3 As DataRow = data_table_ssd_3.NewRow()
        newRow_3("ssd_letter") = ""
        newRow_3("ssd_name") = ""
        data_table_ssd_3.Rows.Add(newRow_3)

        Dim newRow_4 As DataRow = data_table_ssd_4.NewRow()
        newRow_4("ssd_letter") = ""
        newRow_4("ssd_name") = ""
        data_table_ssd_4.Rows.Add(newRow_4)

        Dim newRow_5 As DataRow = data_table_ssd_5.NewRow()
        newRow_5("ssd_letter") = ""
        newRow_5("ssd_name") = ""
        data_table_ssd_5.Rows.Add(newRow_5)

        Dim newRow_6 As DataRow = data_table_keys.NewRow()
        newRow_6("farmer_public_key") = ""
        newRow_6("pool_public_key") = ""
        data_table_keys.Rows.Add(newRow_6)

        Dim newRow_7 As DataRow = data_table_config_daemon_dir.NewRow()
        newRow_7("daemon_dir") = default_daemon_dir
        data_table_config_daemon_dir.Rows.Add(newRow_7)

        dataSet.AcceptChanges()

        Dim json As String = JsonConvert.SerializeObject(dataSet, Formatting.Indented)

        Dim config_file As System.IO.StreamWriter
        config_file = My.Computer.FileSystem.OpenTextFileWriter(config_folder & "\settings.json", False)
        config_file.Write(json)
        config_file.Close()
    End Sub

    Function read_settings_config()
        Dim json As String
        Dim fileReader As System.IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(config_folder & "\settings.json")
        json = fileReader.ReadToEnd()
        fileReader.Dispose()

        Dim json_object As JObject = JObject.Parse(json)

        ssd_1_letter = json_object.SelectToken("ssd_1[0].ssd_letter")
        ssd_1_name = json_object.SelectToken("ssd_1[0].ssd_name")

        ssd_2_letter = json_object.SelectToken("ssd_2[0].ssd_letter")
        ssd_2_name = json_object.SelectToken("ssd_2[0].ssd_name")

        ssd_3_letter = json_object.SelectToken("ssd_3[0].ssd_letter")
        ssd_3_name = json_object.SelectToken("ssd_3[0].ssd_name")

        ssd_4_letter = json_object.SelectToken("ssd_4[0].ssd_letter")
        ssd_4_name = json_object.SelectToken("ssd_4[0].ssd_name")

        ssd_5_letter = json_object.SelectToken("ssd_5[0].ssd_letter")
        ssd_5_name = json_object.SelectToken("ssd_5[0].ssd_name")

        key_farmer = json_object.SelectToken("keys[0].farmer_public_key")
        key_pool = json_object.SelectToken("keys[0].pool_public_key")
        If key_farmer = "" And key_pool = "" Then
            extra_keys = ""
        Else
            extra_keys = " --farmer_public_key " & key_farmer & " --pool_public_key " & key_pool
        End If

        daemon_dir = json_object.SelectToken("config_daemon_dir[0].daemon_dir")

        Return True
    End Function
    Function generate_plot_log_name()
        Dim log_name As String
        Dim time_ As String = TimeString
        Dim date_ As String = DateString
        time_ = time_.Replace(":", "-")
        log_name = "PLOT-[" & time_ & "]-[" & date_ & "]"
        Return log_name
    End Function
    Private Sub plot_start(ssd As Double, arguments As String)
        If plot_1_process_running Then

            If plot_2_process_running Then

                If plot_3_process_running Then

                    If plot_4_process_running Then

                        If plot_5_process_running Then

                            If plot_6_process_running Then

                                If plot_7_process_running Then

                                    If plot_8_process_running Then

                                        If plot_9_process_running Then

                                            If plot_10_process_running Then

                                                If plot_11_process_running Then

                                                    If plot_12_process_running Then
                                                    Else
                                                        plot_12_start(arguments)
                                                        plot_12_process_ssd = ssd
                                                        plot_12_process_running = True
                                                    End If
                                                Else
                                                    plot_11_start(arguments)
                                                    plot_11_process_ssd = ssd
                                                    plot_11_process_running = True
                                                End If
                                            Else
                                                plot_10_start(arguments)
                                                plot_10_process_ssd = ssd
                                                plot_10_process_running = True
                                            End If
                                        Else
                                            plot_9_start(arguments)
                                            plot_9_process_ssd = ssd
                                            plot_9_process_running = True
                                        End If
                                    Else
                                        plot_8_start(arguments)
                                        plot_8_process_ssd = ssd
                                        plot_8_process_running = True
                                    End If
                                Else
                                    plot_7_start(arguments)
                                    plot_7_process_ssd = ssd
                                    plot_7_process_running = True
                                End If
                            Else
                                plot_6_start(arguments)
                                plot_6_process_ssd = ssd
                                plot_6_process_running = True
                            End If
                        Else
                            plot_5_start(arguments)
                            plot_5_process_ssd = ssd
                            plot_5_process_running = True
                        End If
                    Else
                        plot_4_start(arguments)
                        plot_4_process_ssd = ssd
                        plot_4_process_running = True
                    End If
                Else
                    plot_3_start(arguments)
                    plot_3_process_ssd = ssd
                    plot_3_process_running = True
                End If
            Else
                plot_2_start(arguments)
                plot_2_process_ssd = ssd
                plot_2_process_running = True
            End If
        Else
            plot_1_start(arguments)
            plot_1_process_ssd = ssd
            plot_1_process_running = True
        End If

    End Sub
    Private Sub timer_plot_progress_Tick(sender As Object, e As EventArgs) Handles timer_plot_progress.Tick
        If plot_1_process_running Then
            plot_progress(calculate_percent(plot_1_process_logname), plot_1_process_logname, label_plot_1, plot_1_process_ssd, plot_1_progressbar)
        Else
            plot_progress_notrunning(label_plot_1, plot_1_progressbar)
        End If

        If plot_2_process_running Then
            plot_progress(calculate_percent(plot_2_process_logname), plot_2_process_logname, label_plot_2, plot_2_process_ssd, plot_2_progressbar)
        Else
            plot_progress_notrunning(label_plot_2, plot_2_progressbar)
        End If

        If plot_3_process_running Then
            plot_progress(calculate_percent(plot_3_process_logname), plot_3_process_logname, label_plot_3, plot_3_process_ssd, plot_3_progressbar)
        Else
            plot_progress_notrunning(label_plot_3, plot_3_progressbar)
        End If

        If plot_4_process_running Then
            plot_progress(calculate_percent(plot_4_process_logname), plot_4_process_logname, label_plot_4, plot_4_process_ssd, plot_4_progressbar)
        Else
            plot_progress_notrunning(label_plot_4, plot_4_progressbar)
        End If

        If plot_5_process_running Then
            plot_progress(calculate_percent(plot_5_process_logname), plot_5_process_logname, label_plot_5, plot_5_process_ssd, plot_5_progressbar)
        Else
            plot_progress_notrunning(label_plot_5, plot_5_progressbar)
        End If

        If plot_6_process_running Then
            plot_progress(calculate_percent(plot_6_process_logname), plot_6_process_logname, label_plot_6, plot_6_process_ssd, plot_6_progressbar)
        Else
            plot_progress_notrunning(label_plot_6, plot_6_progressbar)
        End If

        If plot_7_process_running Then
            plot_progress(calculate_percent(plot_7_process_logname), plot_7_process_logname, label_plot_7, plot_7_process_ssd, plot_7_progressbar)
        Else
            plot_progress_notrunning(label_plot_7, plot_7_progressbar)
        End If

        If plot_8_process_running Then
            plot_progress(calculate_percent(plot_8_process_logname), plot_8_process_logname, label_plot_8, plot_8_process_ssd, plot_8_progressbar)
        Else
            plot_progress_notrunning(label_plot_8, plot_8_progressbar)
        End If

        If plot_9_process_running Then
            plot_progress(calculate_percent(plot_9_process_logname), plot_9_process_logname, label_plot_9, plot_9_process_ssd, plot_9_progressbar)
        Else
            plot_progress_notrunning(label_plot_9, plot_9_progressbar)
        End If

        If plot_10_process_running Then
            plot_progress(calculate_percent(plot_10_process_logname), plot_10_process_logname, label_plot_10, plot_10_process_ssd, plot_10_progressbar)
        Else
            plot_progress_notrunning(label_plot_10, plot_10_progressbar)
        End If

        If plot_11_process_running Then
            plot_progress(calculate_percent(plot_11_process_logname), plot_11_process_logname, label_plot_11, plot_11_process_ssd, plot_11_progressbar)
        Else
            plot_progress_notrunning(label_plot_11, plot_11_progressbar)
        End If

        If plot_12_process_running Then
            plot_progress(calculate_percent(plot_12_process_logname), plot_12_process_logname, label_plot_12, plot_12_process_ssd, plot_12_progressbar)
        Else
            plot_progress_notrunning(label_plot_12, plot_12_progressbar)
        End If
    End Sub


    Function get_running_plots(ssd As Double)
        Dim plots_running As Double
        If plot_1_process_running Then
            If plot_1_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_2_process_running Then
            If plot_2_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_3_process_running Then
            If plot_3_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_4_process_running Then
            If plot_4_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_5_process_running Then
            If plot_5_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_6_process_running Then
            If plot_6_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_7_process_running Then
            If plot_7_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_8_process_running Then
            If plot_8_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_9_process_running Then
            If plot_9_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_10_process_running Then
            If plot_10_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_11_process_running Then
            If plot_11_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        If plot_12_process_running Then
            If plot_12_process_ssd = ssd Then
                plots_running = plots_running + 1
            End If
        End If
        Return plots_running
    End Function
    Function calculate_percent(logname As String)
        Dim percent As Double
        Dim lineCount As Double
        If My.Computer.FileSystem.FileExists(log_folder & logname & ".log") Then
            lineCount = File.ReadAllLines(log_folder & logname & ".log").Length
        End If
        If lineCount < 801 Then
            percent = (lineCount / 801) * 33.4
        Else
            If lineCount < 834 Then
                percent = 33.4 + ((lineCount - 801) / 33) * 20.43
            Else
                If lineCount < 2474 Then
                    percent = 53.83 + ((lineCount - 834) / 1640) * 42.29
                Else
                    If lineCount < 2620 Then
                        percent = 96.12 + ((lineCount - 2474) / 146) * 3.88
                    End If
                End If
            End If
        End If
        If percent > 100 Then
            percent = 100
        End If
        Return percent
    End Function
    Function plot_progress(plot_percent As Double, plot_logname As String, label As Label, ssd As Double, progressbar As Panel)
        label.Text = "Progress: " & Math.Round(plot_percent, 2) & "%"
        label.Text += " | SSD-" & ssd
        label.Text += " | Name: " & plot_logname
        Dim progressbar_width As Double = plot_percent * (1618 / 100)
        If progressbar_width > 1618 Then
            progressbar_width = 1618
        End If
        progressbar.Width = progressbar_width
        If ssd = 1 Then
            progressbar.BackColor = ssd_1_color
            label.ForeColor = ssd_1_color
        End If
        If ssd = 2 Then
            progressbar.BackColor = ssd_2_color
            label.ForeColor = ssd_2_color
        End If
        If ssd = 3 Then
            progressbar.BackColor = ssd_3_color
            label.ForeColor = ssd_3_color
        End If
        If ssd = 4 Then
            progressbar.BackColor = ssd_4_color
            label.ForeColor = ssd_4_color
        End If
        If ssd = 5 Then
            progressbar.BackColor = ssd_5_color
            label.ForeColor = ssd_5_color
        End If
        Return True
    End Function
    Function plot_progress_notrunning(label As Label, progressbar As Panel)
        label.Text = "Progress: " & "0%"
        label.Text += " | SSD-?"
        label.Text += " | Name: " & "?" & vbNewLine
        progressbar.Width = 0
        Return True
    End Function
    '--------------------------------------------------------------------------------------------[ PLOT PROCESSES ]-----------------------------------------------------------------------------------------------------
    Private Sub plot_1_start(arguments As String)
        plot_1_process_logname = generate_plot_log_name()
        plot_1_process_running = True
        plot_1_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_1_process.StartInfo.Arguments = arguments
        plot_1_process.StartInfo.WorkingDirectory = daemon_dir
        plot_1_process.StartInfo.RedirectStandardError = True
        plot_1_process.StartInfo.RedirectStandardOutput = True
        plot_1_process.EnableRaisingEvents = True
        plot_1_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_1_process.ErrorDataReceived, AddressOf plot1_proc_OutputDataReceived
        AddHandler plot_1_process.OutputDataReceived, AddressOf plot1_proc_OutputDataReceived
        plot_1_process.Start()
        plot_1_process.BeginErrorReadLine()
        plot_1_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot1_UpdateTextBoxDelg(text As String)
    Public plot1_myDelegate As plot1_UpdateTextBoxDelg = New plot1_UpdateTextBoxDelg(AddressOf plot1_UpdateTextBox)
    Public Sub plot1_UpdateTextBox(text As String)
        plot_1_process_log = plot_1_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_1_process_logname & ".log", False)
        log_file.Write(plot_1_process_log)
        log_file.Close()
    End Sub
    Public Sub plot1_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot1_myDelegate, e.Data)
        Else
            plot1_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_2_start(arguments As String)
        plot_2_process_logname = generate_plot_log_name()
        plot_2_process_running = True
        plot_2_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_2_process.StartInfo.Arguments = arguments
        plot_2_process.StartInfo.WorkingDirectory = daemon_dir
        plot_2_process.StartInfo.RedirectStandardError = True
        plot_2_process.StartInfo.RedirectStandardOutput = True
        plot_2_process.EnableRaisingEvents = True
        plot_2_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_2_process.ErrorDataReceived, AddressOf plot2_proc_OutputDataReceived
        AddHandler plot_2_process.OutputDataReceived, AddressOf plot2_proc_OutputDataReceived
        plot_2_process.Start()
        plot_2_process.BeginErrorReadLine()
        plot_2_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot2_UpdateTextBoxDelg(text As String)
    Public plot2_myDelegate As plot2_UpdateTextBoxDelg = New plot2_UpdateTextBoxDelg(AddressOf plot2_UpdateTextBox)
    Public Sub plot2_UpdateTextBox(text As String)
        plot_2_process_log = plot_2_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_2_process_logname & ".log", False)
        log_file.Write(plot_2_process_log)
        log_file.Close()
    End Sub
    Public Sub plot2_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot2_myDelegate, e.Data)
        Else
            plot2_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_3_start(arguments As String)
        plot_3_process_logname = generate_plot_log_name()
        plot_3_process_running = True
        plot_3_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_3_process.StartInfo.Arguments = arguments
        plot_3_process.StartInfo.WorkingDirectory = daemon_dir
        plot_3_process.StartInfo.RedirectStandardError = True
        plot_3_process.StartInfo.RedirectStandardOutput = True
        plot_3_process.EnableRaisingEvents = True
        plot_3_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_3_process.ErrorDataReceived, AddressOf plot3_proc_OutputDataReceived
        AddHandler plot_3_process.OutputDataReceived, AddressOf plot3_proc_OutputDataReceived
        plot_3_process.Start()
        plot_3_process.BeginErrorReadLine()
        plot_3_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot3_UpdateTextBoxDelg(text As String)
    Public plot3_myDelegate As plot3_UpdateTextBoxDelg = New plot3_UpdateTextBoxDelg(AddressOf plot3_UpdateTextBox)
    Public Sub plot3_UpdateTextBox(text As String)
        plot_3_process_log = plot_3_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_3_process_logname & ".log", False)
        log_file.Write(plot_3_process_log)
        log_file.Close()
    End Sub
    Public Sub plot3_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot3_myDelegate, e.Data)
        Else
            plot3_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_4_start(arguments As String)
        plot_4_process_logname = generate_plot_log_name()
        plot_4_process_running = True
        plot_4_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_4_process.StartInfo.Arguments = arguments
        plot_4_process.StartInfo.WorkingDirectory = daemon_dir
        plot_4_process.StartInfo.RedirectStandardError = True
        plot_4_process.StartInfo.RedirectStandardOutput = True
        plot_4_process.EnableRaisingEvents = True
        plot_4_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_4_process.ErrorDataReceived, AddressOf plot4_proc_OutputDataReceived
        AddHandler plot_4_process.OutputDataReceived, AddressOf plot4_proc_OutputDataReceived
        plot_4_process.Start()
        plot_4_process.BeginErrorReadLine()
        plot_4_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot4_UpdateTextBoxDelg(text As String)
    Public plot4_myDelegate As plot4_UpdateTextBoxDelg = New plot4_UpdateTextBoxDelg(AddressOf plot4_UpdateTextBox)
    Public Sub plot4_UpdateTextBox(text As String)
        plot_4_process_log = plot_4_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_4_process_logname & ".log", False)
        log_file.Write(plot_4_process_log)
        log_file.Close()
    End Sub
    Public Sub plot4_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot4_myDelegate, e.Data)
        Else
            plot4_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_5_start(arguments As String)
        plot_5_process_logname = generate_plot_log_name()
        plot_5_process_running = True
        plot_5_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_5_process.StartInfo.Arguments = arguments
        plot_5_process.StartInfo.WorkingDirectory = daemon_dir
        plot_5_process.StartInfo.RedirectStandardError = True
        plot_5_process.StartInfo.RedirectStandardOutput = True
        plot_5_process.EnableRaisingEvents = True
        plot_5_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_5_process.ErrorDataReceived, AddressOf plot5_proc_OutputDataReceived
        AddHandler plot_5_process.OutputDataReceived, AddressOf plot5_proc_OutputDataReceived
        plot_5_process.Start()
        plot_5_process.BeginErrorReadLine()
        plot_5_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot5_UpdateTextBoxDelg(text As String)
    Public plot5_myDelegate As plot5_UpdateTextBoxDelg = New plot5_UpdateTextBoxDelg(AddressOf plot5_UpdateTextBox)
    Public Sub plot5_UpdateTextBox(text As String)
        plot_5_process_log = plot_5_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_5_process_logname & ".log", False)
        log_file.Write(plot_5_process_log)
        log_file.Close()
    End Sub
    Public Sub plot5_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot5_myDelegate, e.Data)
        Else
            plot5_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_6_start(arguments As String)
        plot_6_process_logname = generate_plot_log_name()
        plot_6_process_running = True
        plot_6_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_6_process.StartInfo.Arguments = arguments
        plot_6_process.StartInfo.WorkingDirectory = daemon_dir
        plot_6_process.StartInfo.RedirectStandardError = True
        plot_6_process.StartInfo.RedirectStandardOutput = True
        plot_6_process.EnableRaisingEvents = True
        plot_6_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_6_process.ErrorDataReceived, AddressOf plot6_proc_OutputDataReceived
        AddHandler plot_6_process.OutputDataReceived, AddressOf plot6_proc_OutputDataReceived
        plot_6_process.Start()
        plot_6_process.BeginErrorReadLine()
        plot_6_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot6_UpdateTextBoxDelg(text As String)
    Public plot6_myDelegate As plot6_UpdateTextBoxDelg = New plot6_UpdateTextBoxDelg(AddressOf plot6_UpdateTextBox)
    Public Sub plot6_UpdateTextBox(text As String)
        plot_6_process_log = plot_6_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_6_process_logname & ".log", False)
        log_file.Write(plot_6_process_log)
        log_file.Close()
    End Sub
    Public Sub plot6_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot6_myDelegate, e.Data)
        Else
            plot6_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_7_start(arguments As String)
        plot_7_process_logname = generate_plot_log_name()
        plot_7_process_running = True
        plot_7_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_7_process.StartInfo.Arguments = arguments
        plot_7_process.StartInfo.WorkingDirectory = daemon_dir
        plot_7_process.StartInfo.RedirectStandardError = True
        plot_7_process.StartInfo.RedirectStandardOutput = True
        plot_7_process.EnableRaisingEvents = True
        plot_7_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_7_process.ErrorDataReceived, AddressOf plot7_proc_OutputDataReceived
        AddHandler plot_7_process.OutputDataReceived, AddressOf plot7_proc_OutputDataReceived
        plot_7_process.Start()
        plot_7_process.BeginErrorReadLine()
        plot_7_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot7_UpdateTextBoxDelg(text As String)
    Public plot7_myDelegate As plot7_UpdateTextBoxDelg = New plot7_UpdateTextBoxDelg(AddressOf plot7_UpdateTextBox)
    Public Sub plot7_UpdateTextBox(text As String)
        plot_7_process_log = plot_7_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_7_process_logname & ".log", False)
        log_file.Write(plot_7_process_log)
        log_file.Close()
    End Sub
    Public Sub plot7_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot7_myDelegate, e.Data)
        Else
            plot7_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_8_start(arguments As String)
        plot_8_process_logname = generate_plot_log_name()
        plot_8_process_running = True
        plot_8_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_8_process.StartInfo.Arguments = arguments
        plot_8_process.StartInfo.WorkingDirectory = daemon_dir
        plot_8_process.StartInfo.RedirectStandardError = True
        plot_8_process.StartInfo.RedirectStandardOutput = True
        plot_8_process.EnableRaisingEvents = True
        plot_8_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_8_process.ErrorDataReceived, AddressOf plot8_proc_OutputDataReceived
        AddHandler plot_8_process.OutputDataReceived, AddressOf plot8_proc_OutputDataReceived
        plot_8_process.Start()
        plot_8_process.BeginErrorReadLine()
        plot_8_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot8_UpdateTextBoxDelg(text As String)
    Public plot8_myDelegate As plot8_UpdateTextBoxDelg = New plot8_UpdateTextBoxDelg(AddressOf plot8_UpdateTextBox)
    Public Sub plot8_UpdateTextBox(text As String)
        plot_8_process_log = plot_8_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_8_process_logname & ".log", False)
        log_file.Write(plot_8_process_log)
        log_file.Close()
    End Sub
    Public Sub plot8_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot8_myDelegate, e.Data)
        Else
            plot8_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_9_start(arguments As String)
        plot_9_process_logname = generate_plot_log_name()
        plot_9_process_running = True
        plot_9_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_9_process.StartInfo.Arguments = arguments
        plot_9_process.StartInfo.WorkingDirectory = daemon_dir
        plot_9_process.StartInfo.RedirectStandardError = True
        plot_9_process.StartInfo.RedirectStandardOutput = True
        plot_9_process.EnableRaisingEvents = True
        plot_9_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_9_process.ErrorDataReceived, AddressOf plot9_proc_OutputDataReceived
        AddHandler plot_9_process.OutputDataReceived, AddressOf plot9_proc_OutputDataReceived
        plot_9_process.Start()
        plot_9_process.BeginErrorReadLine()
        plot_9_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot9_UpdateTextBoxDelg(text As String)
    Public plot9_myDelegate As plot9_UpdateTextBoxDelg = New plot9_UpdateTextBoxDelg(AddressOf plot9_UpdateTextBox)
    Public Sub plot9_UpdateTextBox(text As String)
        plot_9_process_log = plot_9_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_9_process_logname & ".log", False)
        log_file.Write(plot_9_process_log)
        log_file.Close()
    End Sub
    Public Sub plot9_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot9_myDelegate, e.Data)
        Else
            plot9_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_10_start(arguments As String)
        plot_10_process_logname = generate_plot_log_name()
        plot_10_process_running = True
        plot_10_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_10_process.StartInfo.Arguments = arguments
        plot_10_process.StartInfo.WorkingDirectory = daemon_dir
        plot_10_process.StartInfo.RedirectStandardError = True
        plot_10_process.StartInfo.RedirectStandardOutput = True
        plot_10_process.EnableRaisingEvents = True
        plot_10_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_10_process.ErrorDataReceived, AddressOf plot10_proc_OutputDataReceived
        AddHandler plot_10_process.OutputDataReceived, AddressOf plot10_proc_OutputDataReceived
        plot_10_process.Start()
        plot_10_process.BeginErrorReadLine()
        plot_10_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot10_UpdateTextBoxDelg(text As String)
    Public plot10_myDelegate As plot10_UpdateTextBoxDelg = New plot10_UpdateTextBoxDelg(AddressOf plot10_UpdateTextBox)
    Public Sub plot10_UpdateTextBox(text As String)
        plot_10_process_log = plot_10_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_10_process_logname & ".log", False)
        log_file.Write(plot_10_process_log)
        log_file.Close()
    End Sub
    Public Sub plot10_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot10_myDelegate, e.Data)
        Else
            plot10_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_11_start(arguments As String)
        plot_11_process_logname = generate_plot_log_name()
        plot_11_process_running = True
        plot_11_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_11_process.StartInfo.Arguments = arguments
        plot_11_process.StartInfo.WorkingDirectory = daemon_dir
        plot_11_process.StartInfo.RedirectStandardError = True
        plot_11_process.StartInfo.RedirectStandardOutput = True
        plot_11_process.EnableRaisingEvents = True
        plot_11_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_11_process.ErrorDataReceived, AddressOf plot11_proc_OutputDataReceived
        AddHandler plot_11_process.OutputDataReceived, AddressOf plot11_proc_OutputDataReceived
        plot_11_process.Start()
        plot_11_process.BeginErrorReadLine()
        plot_11_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot11_UpdateTextBoxDelg(text As String)
    Public plot11_myDelegate As plot11_UpdateTextBoxDelg = New plot11_UpdateTextBoxDelg(AddressOf plot11_UpdateTextBox)
    Public Sub plot11_UpdateTextBox(text As String)
        plot_11_process_log = plot_11_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_11_process_logname & ".log", False)
        log_file.Write(plot_11_process_log)
        log_file.Close()
    End Sub
    Public Sub plot11_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot11_myDelegate, e.Data)
        Else
            plot11_UpdateTextBox(e.Data)
        End If
    End Sub
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub plot_12_start(arguments As String)
        plot_12_process_logname = generate_plot_log_name()
        plot_12_process_running = True
        plot_12_process.StartInfo.FileName = daemon_dir & "\chia.exe"
        plot_12_process.StartInfo.Arguments = arguments
        plot_12_process.StartInfo.WorkingDirectory = daemon_dir
        plot_12_process.StartInfo.RedirectStandardError = True
        plot_12_process.StartInfo.RedirectStandardOutput = True
        plot_12_process.EnableRaisingEvents = True
        plot_12_process.StartInfo.UseShellExecute = False
        Application.DoEvents()
        AddHandler plot_12_process.ErrorDataReceived, AddressOf plot12_proc_OutputDataReceived
        AddHandler plot_12_process.OutputDataReceived, AddressOf plot12_proc_OutputDataReceived
        plot_12_process.Start()
        plot_12_process.BeginErrorReadLine()
        plot_12_process.BeginOutputReadLine()
    End Sub
    Delegate Sub plot12_UpdateTextBoxDelg(text As String)
    Public plot12_myDelegate As plot12_UpdateTextBoxDelg = New plot12_UpdateTextBoxDelg(AddressOf plot12_UpdateTextBox)
    Public Sub plot12_UpdateTextBox(text As String)
        plot_12_process_log = plot_12_process_log & text & vbNewLine
        Dim log_file As System.IO.StreamWriter
        log_file = My.Computer.FileSystem.OpenTextFileWriter(log_folder & plot_12_process_logname & ".log", False)
        log_file.Write(plot_12_process_log)
        log_file.Close()
    End Sub
    Public Sub plot12_proc_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If Me.InvokeRequired = True Then
            Me.Invoke(plot12_myDelegate, e.Data)
        Else
            plot12_UpdateTextBox(e.Data)
        End If
    End Sub
    '--------------------------------------------------------------------------------------------[ PLOT PROCESSES ]-----------------------------------------------------------------------------------------------------
    Private Sub timer_plot_check_Tick(sender As Object, e As EventArgs) Handles timer_plot_check.Tick
        '[Check for exited plots]--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        If plot_1_process_running = True Then
            If plot_1_process.HasExited Then
                RemoveHandler plot_1_process.ErrorDataReceived, AddressOf plot1_proc_OutputDataReceived
                RemoveHandler plot_1_process.OutputDataReceived, AddressOf plot1_proc_OutputDataReceived
                plot_1_process.CancelErrorRead()
                plot_1_process.CancelOutputRead()
                plot_1_process_log = Nothing
                plot_1_process_running = False
                plot_ssd_add_done(plot_1_process_ssd)
            End If
        End If

        If plot_2_process_running = True Then
            If plot_2_process.HasExited Then
                RemoveHandler plot_2_process.ErrorDataReceived, AddressOf plot2_proc_OutputDataReceived
                RemoveHandler plot_2_process.OutputDataReceived, AddressOf plot2_proc_OutputDataReceived
                plot_2_process.CancelErrorRead()
                plot_2_process.CancelOutputRead()
                plot_2_process_log = Nothing
                plot_2_process_running = False
                plot_ssd_add_done(plot_2_process_ssd)
            End If
        End If

        If plot_3_process_running = True Then
            If plot_3_process.HasExited Then
                RemoveHandler plot_3_process.ErrorDataReceived, AddressOf plot3_proc_OutputDataReceived
                RemoveHandler plot_3_process.OutputDataReceived, AddressOf plot3_proc_OutputDataReceived
                plot_3_process.CancelErrorRead()
                plot_3_process.CancelOutputRead()
                plot_3_process_log = Nothing
                plot_3_process_running = False
                plot_ssd_add_done(plot_3_process_ssd)
            End If
        End If

        If plot_4_process_running = True Then
            If plot_4_process.HasExited Then
                RemoveHandler plot_4_process.ErrorDataReceived, AddressOf plot4_proc_OutputDataReceived
                RemoveHandler plot_4_process.OutputDataReceived, AddressOf plot4_proc_OutputDataReceived
                plot_4_process.CancelErrorRead()
                plot_4_process.CancelOutputRead()
                plot_4_process_log = Nothing
                plot_4_process_running = False
                plot_ssd_add_done(plot_4_process_ssd)
            End If
        End If

        If plot_5_process_running = True Then
            If plot_5_process.HasExited Then
                RemoveHandler plot_5_process.ErrorDataReceived, AddressOf plot5_proc_OutputDataReceived
                RemoveHandler plot_5_process.OutputDataReceived, AddressOf plot5_proc_OutputDataReceived
                plot_5_process.CancelErrorRead()
                plot_5_process.CancelOutputRead()
                plot_5_process_log = Nothing
                plot_5_process_running = False
                plot_ssd_add_done(plot_5_process_ssd)
            End If
        End If

        If plot_6_process_running = True Then
            If plot_6_process.HasExited Then
                RemoveHandler plot_6_process.ErrorDataReceived, AddressOf plot6_proc_OutputDataReceived
                RemoveHandler plot_6_process.OutputDataReceived, AddressOf plot6_proc_OutputDataReceived
                plot_6_process.CancelErrorRead()
                plot_6_process.CancelOutputRead()
                plot_6_process_log = Nothing
                plot_6_process_running = False
                plot_ssd_add_done(plot_6_process_ssd)
            End If
        End If

        If plot_7_process_running = True Then
            If plot_7_process.HasExited Then
                RemoveHandler plot_7_process.ErrorDataReceived, AddressOf plot7_proc_OutputDataReceived
                RemoveHandler plot_7_process.OutputDataReceived, AddressOf plot7_proc_OutputDataReceived
                plot_7_process.CancelErrorRead()
                plot_7_process.CancelOutputRead()
                plot_7_process_log = Nothing
                plot_7_process_running = False
                plot_ssd_add_done(plot_7_process_ssd)
            End If
        End If

        If plot_8_process_running = True Then
            If plot_8_process.HasExited Then
                RemoveHandler plot_8_process.ErrorDataReceived, AddressOf plot8_proc_OutputDataReceived
                RemoveHandler plot_8_process.OutputDataReceived, AddressOf plot8_proc_OutputDataReceived
                plot_8_process.CancelErrorRead()
                plot_8_process.CancelOutputRead()
                plot_8_process_log = Nothing
                plot_8_process_running = False
                plot_ssd_add_done(plot_8_process_ssd)
            End If
        End If


        If plot_9_process_running = True Then
            If plot_9_process.HasExited Then
                RemoveHandler plot_9_process.ErrorDataReceived, AddressOf plot9_proc_OutputDataReceived
                RemoveHandler plot_9_process.OutputDataReceived, AddressOf plot9_proc_OutputDataReceived
                plot_9_process.CancelErrorRead()
                plot_9_process.CancelOutputRead()
                plot_9_process_log = Nothing
                plot_9_process_running = False
                plot_ssd_add_done(plot_9_process_ssd)
            End If
        End If

        If plot_10_process_running = True Then
            If plot_10_process.HasExited Then
                RemoveHandler plot_10_process.ErrorDataReceived, AddressOf plot10_proc_OutputDataReceived
                RemoveHandler plot_10_process.OutputDataReceived, AddressOf plot10_proc_OutputDataReceived
                plot_10_process.CancelErrorRead()
                plot_10_process.CancelOutputRead()
                plot_10_process_log = Nothing
                plot_10_process_running = False
                plot_ssd_add_done(plot_10_process_ssd)
            End If
        End If

        If plot_11_process_running = True Then
            If plot_11_process.HasExited Then
                RemoveHandler plot_11_process.ErrorDataReceived, AddressOf plot11_proc_OutputDataReceived
                RemoveHandler plot_11_process.OutputDataReceived, AddressOf plot11_proc_OutputDataReceived
                plot_11_process.CancelErrorRead()
                plot_11_process.CancelOutputRead()
                plot_11_process_log = Nothing
                plot_11_process_running = False
                plot_ssd_add_done(plot_11_process_ssd)
            End If
        End If

        If plot_12_process_running = True Then
            If plot_12_process.HasExited Then
                RemoveHandler plot_12_process.ErrorDataReceived, AddressOf plot12_proc_OutputDataReceived
                RemoveHandler plot_12_process.OutputDataReceived, AddressOf plot12_proc_OutputDataReceived
                plot_12_process.CancelErrorRead()
                plot_12_process.CancelOutputRead()
                plot_12_process_log = Nothing
                plot_12_process_running = False
                plot_ssd_add_done(plot_12_process_ssd)
            End If
        End If
        '[Check for exited plots]--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        '[Start new plots on ssds if timer ready]----------------------------------------------------------------------------------------------------------------------------------------------------
        If ssd_1_timer_count = ssd_1_timer_delay And timer_ssd_1.Enabled = True Then
            If ssd_1_plots_running < ssd_1_max_concurrent_plots Then
                If ssd_1_plots_started < ssd_1_plots_to_do Then
                    ssd_1_timer_count = 0
                    Dim arguments As String = "plots create --size " & ssd_1_plot_type & " --num 1 --buffer " & ssd_1_plot_memory & " --num_threads " & ssd_1_plot_threads & " --tmp_dir " & ssd_1_plot_ssd & " --final_dir " & ssd_1_plot_hdd & extra_keys
                    plot_start(1, arguments)
                    ssd_1_plots_started = ssd_1_plots_started + 1
                    ssd_1_plots_running = ssd_1_plots_running + 1
                    label_ssd_1_status.Text = "Plots done: " & ssd_1_plots_done & "/" & ssd_1_plots_to_do & vbNewLine
                    label_ssd_1_status.Text += "Plots running: " & ssd_1_plots_running & "/" & ssd_1_max_concurrent_plots & vbNewLine
                    label_ssd_1_status.Text += "Plots started: " & ssd_1_plots_started & "/" & ssd_1_plots_to_do
                End If
            End If
        Else
            If ssd_1_first_plot = True And timer_ssd_1.Enabled = True Then
                If ssd_1_plots_running < ssd_1_max_concurrent_plots Then
                    If ssd_1_plots_started < ssd_1_plots_to_do Then
                        ssd_1_timer_count = 0
                        ssd_1_first_plot = False
                        Dim arguments As String = "plots create --size " & ssd_1_plot_type & " --num 1 --buffer " & ssd_1_plot_memory & " --num_threads " & ssd_1_plot_threads & " --tmp_dir " & ssd_1_plot_ssd & " --final_dir " & ssd_1_plot_hdd & extra_keys
                        plot_start(1, arguments)
                        ssd_1_plots_started = ssd_1_plots_started + 1
                        ssd_1_plots_running = ssd_1_plots_running + 1
                        label_ssd_1_status.Text = "Plots done: " & ssd_1_plots_done & "/" & ssd_1_plots_to_do & vbNewLine
                        label_ssd_1_status.Text += "Plots running: " & ssd_1_plots_running & "/" & ssd_1_max_concurrent_plots & vbNewLine
                        label_ssd_1_status.Text += "Plots started: " & ssd_1_plots_started & "/" & ssd_1_plots_to_do
                    End If
                End If
            End If
        End If

        If ssd_2_timer_count = ssd_2_timer_delay Then
            If ssd_2_plots_running < ssd_2_max_concurrent_plots Then
                If ssd_2_plots_started < ssd_2_plots_to_do Then
                    ssd_2_timer_count = 0
                    Dim arguments As String = "plots create --size " & ssd_2_plot_type & " --num 1 --buffer " & ssd_2_plot_memory & " --num_threads " & ssd_2_plot_threads & " --tmp_dir " & ssd_2_plot_ssd & " --final_dir " & ssd_2_plot_hdd & extra_keys
                    plot_start(2, arguments)
                    ssd_2_plots_started = ssd_2_plots_started + 1
                    ssd_2_plots_running = ssd_2_plots_running + 1
                    label_ssd_2_status.Text = "Plots done: " & ssd_2_plots_done & "/" & ssd_2_plots_to_do & vbNewLine
                    label_ssd_2_status.Text += "Plots running: " & ssd_2_plots_running & "/" & ssd_2_max_concurrent_plots & vbNewLine
                    label_ssd_2_status.Text += "Plots started: " & ssd_2_plots_started & "/" & ssd_2_plots_to_do
                End If
            End If
        Else
            If ssd_2_first_plot = True And timer_ssd_2.Enabled = True Then
                If ssd_2_plots_running < ssd_2_max_concurrent_plots Then
                    If ssd_2_plots_started < ssd_2_plots_to_do Then
                        ssd_2_timer_count = 0
                        ssd_2_first_plot = False
                        Dim arguments As String = "plots create --size " & ssd_2_plot_type & " --num 1 --buffer " & ssd_2_plot_memory & " --num_threads " & ssd_2_plot_threads & " --tmp_dir " & ssd_2_plot_ssd & " --final_dir " & ssd_2_plot_hdd & extra_keys
                        plot_start(2, arguments)
                        ssd_2_plots_started = ssd_2_plots_started + 1
                        ssd_2_plots_running = ssd_2_plots_running + 1
                        label_ssd_2_status.Text = "Plots done: " & ssd_2_plots_done & "/" & ssd_2_plots_to_do & vbNewLine
                        label_ssd_2_status.Text += "Plots running: " & ssd_2_plots_running & "/" & ssd_2_max_concurrent_plots & vbNewLine
                        label_ssd_2_status.Text += "Plots started: " & ssd_2_plots_started & "/" & ssd_2_plots_to_do
                    End If
                End If
            End If
        End If

        If ssd_3_timer_count = ssd_3_timer_delay Then
            If ssd_3_plots_running < ssd_3_max_concurrent_plots Then
                If ssd_3_plots_started < ssd_3_plots_to_do Then
                    ssd_3_timer_count = 0
                    Dim arguments As String = "plots create --size " & ssd_3_plot_type & " --num 1 --buffer " & ssd_3_plot_memory & " --num_threads " & ssd_3_plot_threads & " --tmp_dir " & ssd_3_plot_ssd & " --final_dir " & ssd_3_plot_hdd
                    plot_start(3, arguments)
                    ssd_3_plots_started = ssd_3_plots_started + 1
                    ssd_3_plots_running = ssd_3_plots_running + 1
                    label_ssd_3_status.Text = "Plots done: " & ssd_3_plots_done & "/" & ssd_3_plots_to_do & vbNewLine
                    label_ssd_3_status.Text += "Plots running: " & ssd_3_plots_running & "/" & ssd_3_max_concurrent_plots & vbNewLine
                    label_ssd_3_status.Text += "Plots started: " & ssd_3_plots_started & "/" & ssd_3_plots_to_do
                End If
            End If
        Else
            If ssd_3_first_plot = True And timer_ssd_3.Enabled = True Then
                If ssd_3_plots_running < ssd_3_max_concurrent_plots Then
                    If ssd_3_plots_started < ssd_3_plots_to_do Then
                        ssd_3_timer_count = 0
                        ssd_3_first_plot = False
                        Dim arguments As String = "plots create --size " & ssd_3_plot_type & " --num 1 --buffer " & ssd_3_plot_memory & " --num_threads " & ssd_3_plot_threads & " --tmp_dir " & ssd_3_plot_ssd & " --final_dir " & ssd_3_plot_hdd
                        plot_start(3, arguments)
                        ssd_3_plots_started = ssd_3_plots_started + 1
                        ssd_3_plots_running = ssd_3_plots_running + 1
                        label_ssd_3_status.Text = "Plots done: " & ssd_3_plots_done & "/" & ssd_3_plots_to_do & vbNewLine
                        label_ssd_3_status.Text += "Plots running: " & ssd_3_plots_running & "/" & ssd_3_max_concurrent_plots & vbNewLine
                        label_ssd_3_status.Text += "Plots started: " & ssd_3_plots_started & "/" & ssd_3_plots_to_do
                    End If
                End If
            End If
        End If

        If ssd_4_timer_count = ssd_4_timer_delay Then
            If ssd_4_plots_running < ssd_4_max_concurrent_plots Then
                If ssd_4_plots_started < ssd_4_plots_to_do Then
                    ssd_4_timer_count = 0
                    Dim arguments As String = "plots create --size " & ssd_4_plot_type & " --num 1 --buffer " & ssd_4_plot_memory & " --num_threads " & ssd_4_plot_threads & " --tmp_dir " & ssd_4_plot_ssd & " --final_dir " & ssd_4_plot_hdd & extra_keys
                    plot_start(4, arguments)
                    ssd_4_plots_started = ssd_4_plots_started + 1
                    ssd_4_plots_running = ssd_4_plots_running + 1
                    label_ssd_4_status.Text = "Plots done: " & ssd_4_plots_done & "/" & ssd_4_plots_to_do & vbNewLine
                    label_ssd_4_status.Text += "Plots running: " & ssd_4_plots_running & "/" & ssd_4_max_concurrent_plots & vbNewLine
                    label_ssd_4_status.Text += "Plots started: " & ssd_4_plots_started & "/" & ssd_4_plots_to_do
                End If
            End If
        Else
            If ssd_4_first_plot = True And timer_ssd_4.Enabled = True Then
                If ssd_4_plots_running < ssd_4_max_concurrent_plots Then
                    If ssd_4_plots_started < ssd_4_plots_to_do Then
                        ssd_4_timer_count = 0
                        ssd_4_first_plot = False
                        Dim arguments As String = "plots create --size " & ssd_4_plot_type & " --num 1 --buffer " & ssd_4_plot_memory & " --num_threads " & ssd_4_plot_threads & " --tmp_dir " & ssd_4_plot_ssd & " --final_dir " & ssd_4_plot_hdd & extra_keys
                        plot_start(4, arguments)
                        ssd_4_plots_started = ssd_4_plots_started + 1
                        ssd_4_plots_running = ssd_4_plots_running + 1
                        label_ssd_4_status.Text = "Plots done: " & ssd_4_plots_done & "/" & ssd_4_plots_to_do & vbNewLine
                        label_ssd_4_status.Text += "Plots running: " & ssd_4_plots_running & "/" & ssd_4_max_concurrent_plots & vbNewLine
                        label_ssd_4_status.Text += "Plots started: " & ssd_4_plots_started & "/" & ssd_4_plots_to_do
                    End If
                End If
            End If
        End If

        If ssd_5_timer_count = ssd_5_timer_delay Then
            If ssd_5_plots_running < ssd_5_max_concurrent_plots Then
                If ssd_5_plots_started < ssd_5_plots_to_do Then
                    ssd_5_timer_count = 0
                    Dim arguments As String = "plots create --size " & ssd_5_plot_type & " --num 1 --buffer " & ssd_5_plot_memory & " --num_threads " & ssd_5_plot_threads & " --tmp_dir " & ssd_5_plot_ssd & " --final_dir " & ssd_5_plot_hdd & extra_keys
                    plot_start(5, arguments)
                    ssd_5_plots_started = ssd_5_plots_started + 1
                    ssd_5_plots_running = ssd_5_plots_running + 1
                    label_ssd_5_status.Text = "Plots done: " & ssd_5_plots_done & "/" & ssd_5_plots_to_do & vbNewLine
                    label_ssd_5_status.Text += "Plots running: " & ssd_5_plots_running & "/" & ssd_5_max_concurrent_plots & vbNewLine
                    label_ssd_5_status.Text += "Plots started: " & ssd_5_plots_started & "/" & ssd_5_plots_to_do
                End If
            End If
        Else
            If ssd_5_first_plot = True And timer_ssd_5.Enabled = True Then
                If ssd_5_plots_running < ssd_5_max_concurrent_plots Then
                    If ssd_5_plots_started < ssd_5_plots_to_do Then
                        ssd_5_timer_count = 0
                        ssd_5_first_plot = False
                        Dim arguments As String = "plots create --size " & ssd_5_plot_type & " --num 1 --buffer " & ssd_5_plot_memory & " --num_threads " & ssd_5_plot_threads & " --tmp_dir " & ssd_5_plot_ssd & " --final_dir " & ssd_5_plot_hdd & extra_keys
                        plot_start(5, arguments)
                        ssd_5_plots_started = ssd_5_plots_started + 1
                        ssd_5_plots_running = ssd_5_plots_running + 1
                        label_ssd_5_status.Text = "Plots done: " & ssd_5_plots_done & "/" & ssd_5_plots_to_do & vbNewLine
                        label_ssd_5_status.Text += "Plots running: " & ssd_5_plots_running & "/" & ssd_5_max_concurrent_plots & vbNewLine
                        label_ssd_5_status.Text += "Plots started: " & ssd_5_plots_started & "/" & ssd_5_plots_to_do
                    End If
                End If
            End If
        End If

        '[Start new plots on ssds if timer ready]----------------------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    '[Add plot done to ssd]--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Function plot_ssd_add_done(ssd As Double)
        If ssd = 1 Then
            ssd_1_plots_done = ssd_1_plots_done + 1
            ssd_1_plots_running = ssd_1_plots_running - 1
            label_ssd_1_status.Text = "Plots done: " & ssd_1_plots_done & "/" & ssd_1_plots_to_do & vbNewLine
            label_ssd_1_status.Text += "Plots running: " & ssd_1_plots_running & "/" & ssd_1_max_concurrent_plots & vbNewLine
            label_ssd_1_status.Text += "Plots started: " & ssd_1_plots_started & "/" & ssd_1_plots_to_do
        End If
        If ssd = 2 Then
            ssd_2_plots_done = ssd_2_plots_done + 1
            ssd_2_plots_running = ssd_2_plots_running - 1
            label_ssd_2_status.Text = "Plots done: " & ssd_2_plots_done & "/" & ssd_2_plots_to_do & vbNewLine
            label_ssd_2_status.Text += "Plots running: " & ssd_2_plots_running & "/" & ssd_2_max_concurrent_plots & vbNewLine
            label_ssd_2_status.Text += "Plots started: " & ssd_2_plots_started & "/" & ssd_2_plots_to_do
        End If
        If ssd = 3 Then
            ssd_3_plots_done = ssd_3_plots_done + 1
            ssd_3_plots_running = ssd_3_plots_running - 1
            label_ssd_3_status.Text = "Plots done: " & ssd_3_plots_done & "/" & ssd_3_plots_to_do & vbNewLine
            label_ssd_3_status.Text += "Plots running: " & ssd_3_plots_running & "/" & ssd_3_max_concurrent_plots & vbNewLine
            label_ssd_3_status.Text += "Plots started: " & ssd_3_plots_started & "/" & ssd_3_plots_to_do
        End If
        If ssd = 4 Then
            ssd_4_plots_done = ssd_4_plots_done + 1
            ssd_4_plots_running = ssd_4_plots_running - 1
            label_ssd_4_status.Text = "Plots done: " & ssd_4_plots_done & "/" & ssd_4_plots_to_do & vbNewLine
            label_ssd_4_status.Text += "Plots running: " & ssd_4_plots_running & "/" & ssd_4_max_concurrent_plots & vbNewLine
            label_ssd_4_status.Text += "Plots started: " & ssd_4_plots_started & "/" & ssd_4_plots_to_do
        End If
        If ssd = 5 Then
            ssd_5_plots_done = ssd_5_plots_done + 1
            ssd_5_plots_running = ssd_5_plots_running - 1
            label_ssd_5_status.Text = "Plots done: " & ssd_5_plots_done & "/" & ssd_5_plots_to_do & vbNewLine
            label_ssd_5_status.Text += "Plots running: " & ssd_5_plots_running & "/" & ssd_5_max_concurrent_plots & vbNewLine
            label_ssd_5_status.Text += "Plots started: " & ssd_5_plots_started & "/" & ssd_5_plots_to_do
        End If
        Return True
    End Function
    '[Add plot done to ssd]--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    '[SSD - 1]---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_ssd_1_timer_ctl_Click(sender As Object, e As EventArgs) Handles button_ssd_1_timer_ctl.Click
        If timer_ssd_1.Enabled Then
            timer_ssd_1.Stop()
            button_ssd_1_timer_ctl.Text = "Start"
            button_ssd_1_timer_ctl.ForeColor = Color.Red
        Else
            timer_ssd_1.Start()
            button_ssd_1_timer_ctl.Text = "Stop"
            button_ssd_1_timer_ctl.ForeColor = Color.Green
        End If
    End Sub
    Private Sub button_set_ssd_1_Click(sender As Object, e As EventArgs) Handles button_set_ssd_1.Click
        ssd_1_plot_threads = set_ssd_1_threads_plots.Value
        ssd_1_plot_memory = set_ssd_1_memory_plots.Value
        ssd_1_plot_type = set_ssd_1_type_plots.Value
        ssd_1_plot_ssd = set_ssd_1_ssd_plots.Text
        ssd_1_plot_hdd = set_ssd_1_hdd_plots.Text
        ssd_1_max_concurrent_plots = set_ssd_1_concurent_plots.Value
        ssd_1_plots_to_do = set_ssd_1_plots_to_do.Value
        ssd_1_timer_delay = set_ssd_1_timer_delay.Value * 60
        label_ssd_1_status.Text = "Plots done: " & ssd_1_plots_done & "/" & ssd_1_plots_to_do & vbNewLine
        label_ssd_1_status.Text += "Plots running: " & ssd_1_plots_running & "/" & ssd_1_max_concurrent_plots & vbNewLine
        label_ssd_1_status.Text += "Plots started: " & ssd_1_plots_started & "/" & ssd_1_plots_to_do
        MessageBox.Show("INFO SET: " & "Concurrent-plots:" & ssd_1_max_concurrent_plots & " Threads:" & ssd_1_plot_threads & " Memory:" & ssd_1_plot_memory & " Type:" & ssd_1_plot_type & " SSD: " & ssd_1_plot_ssd & " HHD: " & ssd_1_plot_hdd, "SSD-1 Info")
    End Sub
    Private Sub button_ssd_1_reset_Click(sender As Object, e As EventArgs) Handles button_ssd_1_reset.Click
        ssd_1_plots_done = 0
        ssd_1_timer_count = 0
        ssd_1_plots_started = 0
        ssd_1_first_plot = True
        label_ssd_1_status.Text = "Plots done: " & ssd_1_plots_done & "/" & ssd_1_plots_to_do & vbNewLine
        label_ssd_1_status.Text += "Plots running: " & ssd_1_plots_running & "/" & ssd_1_max_concurrent_plots & vbNewLine
        label_ssd_1_status.Text += "Plots started: " & ssd_1_plots_started & "/" & ssd_1_plots_to_do
        label_timer_progress_1.Text = Math.Round((ssd_1_timer_count / 60), 1) & "Min / " & ssd_1_timer_delay & "Min | Time left: " & Math.Round((ssd_1_timer_delay - (ssd_1_timer_count / 60)), 1) & "Min"
        progressbar_timer_1.Width = ssd_1_timer_count
    End Sub
    Private Sub button_set_ssd_1_color_Click(sender As Object, e As EventArgs) Handles button_set_ssd_1_color.Click
        Try
            Dim colorbox As String = set_ssd_1_color.Text
            colorbox.Replace(" ", "")
            Dim colors As String() = colorbox.Split(New Char() {","})
            Dim color_r As Integer = colors(0)
            Dim color_g As Integer = colors(1)
            Dim color_b As Integer = colors(2)
            ssd_1_color = Color.FromArgb(color_r, color_g, color_b)
            groupbox_ssd_1.ForeColor = ssd_1_color
            progressbar_timer_1.BackColor = ssd_1_color
            groupbox_ssd_color(set_ssd_1_threads_plots, set_ssd_1_memory_plots, set_ssd_1_type_plots, set_ssd_1_ssd_plots, set_ssd_1_hdd_plots, button_set_ssd_1, set_ssd_1_concurent_plots, set_ssd_1_plots_to_do, set_ssd_1_timer_delay, button_ssd_1_reset, label_ssd_1_status, set_ssd_1_color, button_set_ssd_1_color, ssd_1_color)
            groupbox_ssd_color_label(label_ssd_1_threads, label_ssd_1_memory, label_ssd_1_type, label_ssd_1_ssd, label_ssd_1_hdd, label_ssd_1_max_concurrent_plots, label_ssd_1_plots_to_do, label_ssd_1_timer_delay, label_ssd_1_color, ssd_1_color)
        Catch ex As Exception
            MessageBox.Show("Failed to apply colors", "SSD-1")
        End Try
    End Sub
    Private Sub timer_ssd_1_Tick(sender As Object, e As EventArgs) Handles timer_ssd_1.Tick
        Try
            If ssd_1_timer_count < ssd_1_timer_delay Then
                ssd_1_timer_count = ssd_1_timer_count + 1
            End If
            label_timer_progress_1.Text = Math.Round((ssd_1_timer_count / 60), 1) & "Min / " & (ssd_1_timer_delay / 60) & "Min (" & Math.Round((ssd_1_timer_count / ssd_1_timer_delay) * 100, 0) & "%) | Time left: " & Math.Round((ssd_1_timer_delay - ssd_1_timer_count) / 60, 1) & "Min"
            Dim progressbar_width As Double = ssd_1_timer_count * (1218 / ssd_1_timer_delay)
            If progressbar_width > 1218 Then
                progressbar_width = 1218
            End If
            progressbar_timer_1.Width = progressbar_width
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub set_ssd_1_timer_delay_ValueChanged(sender As Object, e As EventArgs) Handles set_ssd_1_timer_delay.ValueChanged
        ssd_1_timer_delay = set_ssd_1_timer_delay.Value * 60
    End Sub
    '[SSD - 1]--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    '[SSD - 2]---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_ssd_2_timer_ctl_Click(sender As Object, e As EventArgs) Handles button_ssd_2_timer_ctl.Click
        If timer_ssd_2.Enabled Then
            timer_ssd_2.Stop()
            button_ssd_2_timer_ctl.Text = "Start"
            button_ssd_2_timer_ctl.ForeColor = Color.Red
        Else
            timer_ssd_2.Start()
            button_ssd_2_timer_ctl.Text = "Stop"
            button_ssd_2_timer_ctl.ForeColor = Color.Green
        End If
    End Sub
    Private Sub button_set_ssd_2_Click(sender As Object, e As EventArgs) Handles button_set_ssd_2.Click
        ssd_2_plot_threads = set_ssd_2_threads_plots.Value
        ssd_2_plot_memory = set_ssd_2_memory_plots.Value
        ssd_2_plot_type = set_ssd_2_type_plots.Value
        ssd_2_plot_ssd = set_ssd_2_ssd_plots.Text
        ssd_2_plot_hdd = set_ssd_2_hdd_plots.Text
        ssd_2_max_concurrent_plots = set_ssd_2_concurent_plots.Value
        ssd_2_plots_to_do = set_ssd_2_plots_to_do.Value
        ssd_2_timer_delay = set_ssd_2_timer_delay.Value * 60
        label_ssd_2_status.Text = "Plots done: " & ssd_2_plots_done & "/" & ssd_2_plots_to_do & vbNewLine
        label_ssd_2_status.Text += "Plots running: " & ssd_2_plots_running & "/" & ssd_2_max_concurrent_plots & vbNewLine
        label_ssd_2_status.Text += "Plots started: " & ssd_2_plots_started & "/" & ssd_2_plots_to_do
        MessageBox.Show("INFO SET: " & "Concurrent-plots:" & ssd_2_max_concurrent_plots & " Threads:" & ssd_2_plot_threads & " Memory:" & ssd_2_plot_memory & " Type:" & ssd_2_plot_type & " SSD: " & ssd_2_plot_ssd & " HHD: " & ssd_2_plot_hdd, "SSD-2 Info")
    End Sub
    Private Sub button_ssd_2_reset_Click(sender As Object, e As EventArgs) Handles button_ssd_2_reset.Click
        ssd_2_plots_done = 0
        ssd_2_timer_count = 0
        ssd_2_plots_started = 0
        ssd_2_first_plot = True
        label_ssd_2_status.Text = "Plots done: " & ssd_2_plots_done & "/" & ssd_2_plots_to_do & vbNewLine
        label_ssd_2_status.Text += "Plots running: " & ssd_2_plots_running & "/" & ssd_2_max_concurrent_plots & vbNewLine
        label_ssd_2_status.Text += "Plots started: " & ssd_2_plots_started & "/" & ssd_2_plots_to_do
        label_timer_progress_2.Text = Math.Round((ssd_2_timer_count / 60), 2) & "Min / " & ssd_2_timer_delay & "Min | Time left: " & Math.Round((ssd_2_timer_delay - (ssd_2_timer_count / 60)), 2) & "Min"
        progressbar_timer_2.Width = ssd_2_timer_count
    End Sub
    Private Sub button_set_ssd_2_color_Click(sender As Object, e As EventArgs) Handles button_set_ssd_2_color.Click
        Try
            Dim colorbox As String = set_ssd_2_color.Text
            colorbox.Replace(" ", "")
            Dim colors As String() = colorbox.Split(New Char() {","})
            Dim color_r As Integer = colors(0)
            Dim color_g As Integer = colors(1)
            Dim color_b As Integer = colors(2)
            ssd_2_color = Color.FromArgb(color_r, color_g, color_b)
            groupbox_ssd_2.ForeColor = ssd_2_color
            progressbar_timer_2.BackColor = ssd_2_color
            groupbox_ssd_color(set_ssd_2_threads_plots, set_ssd_2_memory_plots, set_ssd_2_type_plots, set_ssd_2_ssd_plots, set_ssd_2_hdd_plots, button_set_ssd_2, set_ssd_2_concurent_plots, set_ssd_2_plots_to_do, set_ssd_2_timer_delay, button_ssd_2_reset, label_ssd_2_status, set_ssd_2_color, button_set_ssd_2_color, ssd_2_color)
            groupbox_ssd_color_label(label_ssd_2_threads, label_ssd_2_memory, label_ssd_2_type, label_ssd_2_ssd, label_ssd_2_hdd, label_ssd_2_max_concurrent_plots, label_ssd_2_plots_to_do, label_ssd_2_timer_delay, label_ssd_2_color, ssd_2_color)
        Catch ex As Exception
            MessageBox.Show("Failed to apply colors", "SSD-2")
        End Try
    End Sub
    Private Sub timer_ssd_2_Tick(sender As Object, e As EventArgs) Handles timer_ssd_2.Tick
        Try
            If ssd_2_timer_count < ssd_2_timer_delay Then
                ssd_2_timer_count = ssd_2_timer_count + 1
            End If
            label_timer_progress_2.Text = Math.Round((ssd_2_timer_count / 60), 1) & "Min / " & (ssd_2_timer_delay / 60) & "Min (" & Math.Round((ssd_2_timer_count / ssd_2_timer_delay) * 100, 0) & "%) | Time left: " & Math.Round((ssd_2_timer_delay - ssd_2_timer_count) / 60, 1) & "Min"
            Dim progressbar_width As Double = ssd_2_timer_count * (1218 / ssd_2_timer_delay)
            If progressbar_width > 1218 Then
                progressbar_width = 1218
            End If
            progressbar_timer_2.Width = progressbar_width
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub set_ssd_2_timer_delay_ValueChanged(sender As Object, e As EventArgs) Handles set_ssd_2_timer_delay.ValueChanged
        ssd_2_timer_delay = set_ssd_2_timer_delay.Value * 60
    End Sub
    '[SSD - 2]--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    '[SSD - 3]---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_ssd_3_timer_ctl_Click(sender As Object, e As EventArgs) Handles button_ssd_3_timer_ctl.Click
        If timer_ssd_3.Enabled Then
            timer_ssd_3.Stop()
            button_ssd_3_timer_ctl.Text = "Start"
            button_ssd_3_timer_ctl.ForeColor = Color.Red
        Else
            timer_ssd_3.Start()
            button_ssd_3_timer_ctl.Text = "Stop"
            button_ssd_3_timer_ctl.ForeColor = Color.Green
        End If
    End Sub
    Private Sub button_set_ssd_3_Click(sender As Object, e As EventArgs) Handles button_set_ssd_3.Click
        ssd_3_plot_threads = set_ssd_3_threads_plots.Value
        ssd_3_plot_memory = set_ssd_3_memory_plots.Value
        ssd_3_plot_type = set_ssd_3_type_plots.Value
        ssd_3_plot_ssd = set_ssd_3_ssd_plots.Text
        ssd_3_plot_hdd = set_ssd_3_hdd_plots.Text
        ssd_3_max_concurrent_plots = set_ssd_3_concurent_plots.Value
        ssd_3_plots_to_do = set_ssd_3_plots_to_do.Value
        ssd_3_timer_delay = set_ssd_3_timer_delay.Value * 60
        label_ssd_3_status.Text = "Plots done: " & ssd_3_plots_done & "/" & ssd_3_plots_to_do & vbNewLine
        label_ssd_3_status.Text += "Plots running: " & ssd_3_plots_running & "/" & ssd_3_max_concurrent_plots & vbNewLine
        label_ssd_3_status.Text += "Plots started: " & ssd_3_plots_started & "/" & ssd_3_plots_to_do
        MessageBox.Show("INFO SET: " & "Concurrent-plots:" & ssd_3_max_concurrent_plots & " Threads:" & ssd_3_plot_threads & " Memory:" & ssd_3_plot_memory & " Type:" & ssd_3_plot_type & " SSD: " & ssd_3_plot_ssd & " HHD: " & ssd_3_plot_hdd, "SSD-3 Info")
    End Sub
    Private Sub button_ssd_3_reset_Click(sender As Object, e As EventArgs) Handles button_ssd_3_reset.Click
        ssd_3_plots_done = 0
        ssd_3_timer_count = 0
        ssd_3_plots_started = 0
        ssd_3_first_plot = True
        label_ssd_3_status.Text = "Plots done: " & ssd_3_plots_done & "/" & ssd_3_plots_to_do & vbNewLine
        label_ssd_3_status.Text += "Plots running: " & ssd_3_plots_running & "/" & ssd_3_max_concurrent_plots & vbNewLine
        label_ssd_3_status.Text += "Plots started: " & ssd_3_plots_started & "/" & ssd_3_plots_to_do
        label_timer_progress_3.Text = Math.Round((ssd_3_timer_count / 60), 3) & "Min / " & ssd_3_timer_delay & "Min | Time left: " & Math.Round((ssd_3_timer_delay - (ssd_3_timer_count / 60)), 3) & "Min"
        progressbar_timer_3.Width = ssd_3_timer_count
    End Sub
    Private Sub button_set_ssd_3_color_Click(sender As Object, e As EventArgs) Handles button_set_ssd_3_color.Click
        Try
            Dim colorbox As String = set_ssd_3_color.Text
            colorbox.Replace(" ", "")
            Dim colors As String() = colorbox.Split(New Char() {","})
            Dim color_r As Integer = colors(0)
            Dim color_g As Integer = colors(1)
            Dim color_b As Integer = colors(2)
            ssd_3_color = Color.FromArgb(color_r, color_g, color_b)
            groupbox_ssd_3.ForeColor = ssd_3_color
            progressbar_timer_3.BackColor = ssd_3_color
            groupbox_ssd_color(set_ssd_3_threads_plots, set_ssd_3_memory_plots, set_ssd_3_type_plots, set_ssd_3_ssd_plots, set_ssd_3_hdd_plots, button_set_ssd_3, set_ssd_3_concurent_plots, set_ssd_3_plots_to_do, set_ssd_3_timer_delay, button_ssd_3_reset, label_ssd_3_status, set_ssd_3_color, button_set_ssd_3_color, ssd_3_color)
            groupbox_ssd_color_label(label_ssd_3_threads, label_ssd_3_memory, label_ssd_3_type, label_ssd_3_ssd, label_ssd_3_hdd, label_ssd_3_max_concurrent_plots, label_ssd_3_plots_to_do, label_ssd_3_timer_delay, label_ssd_3_color, ssd_3_color)
        Catch ex As Exception
            MessageBox.Show("Failed to apply colors", "SSD-3")
        End Try
    End Sub
    Private Sub timer_ssd_3_Tick(sender As Object, e As EventArgs) Handles timer_ssd_3.Tick
        Try
            If ssd_3_timer_count < ssd_3_timer_delay Then
                ssd_3_timer_count = ssd_3_timer_count + 1
            End If
            label_timer_progress_3.Text = Math.Round((ssd_3_timer_count / 60), 1) & "Min / " & (ssd_3_timer_delay / 60) & "Min (" & Math.Round((ssd_3_timer_count / ssd_3_timer_delay) * 100, 0) & "%) | Time left: " & Math.Round((ssd_3_timer_delay - ssd_3_timer_count) / 60, 1) & "Min"
            Dim progressbar_width As Double = ssd_3_timer_count * (1218 / ssd_3_timer_delay)
            If progressbar_width > 1218 Then
                progressbar_width = 1218
            End If
            progressbar_timer_3.Width = progressbar_width
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub set_ssd_3_timer_delay_ValueChanged(sender As Object, e As EventArgs) Handles set_ssd_3_timer_delay.ValueChanged
        ssd_3_timer_delay = set_ssd_3_timer_delay.Value * 60
    End Sub
    '[SSD - 3]--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    '[SSD - 4]---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_ssd_4_timer_ctl_Click(sender As Object, e As EventArgs) Handles button_ssd_4_timer_ctl.Click
        If timer_ssd_4.Enabled Then
            timer_ssd_4.Stop()
            button_ssd_4_timer_ctl.Text = "Start"
            button_ssd_4_timer_ctl.ForeColor = Color.Red
        Else
            timer_ssd_4.Start()
            button_ssd_4_timer_ctl.Text = "Stop"
            button_ssd_4_timer_ctl.ForeColor = Color.Green
        End If
    End Sub
    Private Sub button_set_ssd_4_Click(sender As Object, e As EventArgs) Handles button_set_ssd_4.Click
        ssd_4_plot_threads = set_ssd_4_threads_plots.Value
        ssd_4_plot_memory = set_ssd_4_memory_plots.Value
        ssd_4_plot_type = set_ssd_4_type_plots.Value
        ssd_4_plot_ssd = set_ssd_4_ssd_plots.Text
        ssd_4_plot_hdd = set_ssd_4_hdd_plots.Text
        ssd_4_max_concurrent_plots = set_ssd_4_concurent_plots.Value
        ssd_4_plots_to_do = set_ssd_4_plots_to_do.Value
        ssd_4_timer_delay = set_ssd_4_timer_delay.Value * 60
        label_ssd_4_status.Text = "Plots done: " & ssd_4_plots_done & "/" & ssd_4_plots_to_do & vbNewLine
        label_ssd_4_status.Text += "Plots running: " & ssd_4_plots_running & "/" & ssd_4_max_concurrent_plots & vbNewLine
        label_ssd_4_status.Text += "Plots started: " & ssd_4_plots_started & "/" & ssd_4_plots_to_do
        MessageBox.Show("INFO SET: " & "Concurrent-plots:" & ssd_4_max_concurrent_plots & " Threads:" & ssd_4_plot_threads & " Memory:" & ssd_4_plot_memory & " Type:" & ssd_4_plot_type & " SSD: " & ssd_4_plot_ssd & " HHD: " & ssd_4_plot_hdd, "SSD-4 Info")
    End Sub
    Private Sub button_ssd_4_reset_Click(sender As Object, e As EventArgs) Handles button_ssd_4_reset.Click
        ssd_4_plots_done = 0
        ssd_4_timer_count = 0
        ssd_4_plots_started = 0
        ssd_4_first_plot = True
        label_ssd_4_status.Text = "Plots done: " & ssd_4_plots_done & "/" & ssd_4_plots_to_do & vbNewLine
        label_ssd_4_status.Text += "Plots running: " & ssd_4_plots_running & "/" & ssd_4_max_concurrent_plots & vbNewLine
        label_ssd_4_status.Text += "Plots started: " & ssd_4_plots_started & "/" & ssd_4_plots_to_do
        label_timer_progress_4.Text = Math.Round((ssd_4_timer_count / 60), 4) & "Min / " & ssd_4_timer_delay & "Min | Time left: " & Math.Round((ssd_4_timer_delay - (ssd_4_timer_count / 60)), 4) & "Min"
        progressbar_timer_4.Width = ssd_4_timer_count
    End Sub
    Private Sub button_set_ssd_4_color_Click(sender As Object, e As EventArgs) Handles button_set_ssd_4_color.Click
        Try
            Dim colorbox As String = set_ssd_4_color.Text
            colorbox.Replace(" ", "")
            Dim colors As String() = colorbox.Split(New Char() {","})
            Dim color_r As Integer = colors(0)
            Dim color_g As Integer = colors(1)
            Dim color_b As Integer = colors(2)
            ssd_4_color = Color.FromArgb(color_r, color_g, color_b)
            groupbox_ssd_4.ForeColor = ssd_4_color
            progressbar_timer_4.BackColor = ssd_4_color
            groupbox_ssd_color(set_ssd_4_threads_plots, set_ssd_4_memory_plots, set_ssd_4_type_plots, set_ssd_4_ssd_plots, set_ssd_4_hdd_plots, button_set_ssd_4, set_ssd_4_concurent_plots, set_ssd_4_plots_to_do, set_ssd_4_timer_delay, button_ssd_4_reset, label_ssd_4_status, set_ssd_4_color, button_set_ssd_4_color, ssd_4_color)
            groupbox_ssd_color_label(label_ssd_4_threads, label_ssd_4_memory, label_ssd_4_type, label_ssd_4_ssd, label_ssd_4_hdd, label_ssd_4_max_concurrent_plots, label_ssd_4_plots_to_do, label_ssd_4_timer_delay, label_ssd_4_color, ssd_4_color)
        Catch ex As Exception
            MessageBox.Show("Failed to apply colors", "SSD-4")
        End Try
    End Sub
    Private Sub timer_ssd_4_Tick(sender As Object, e As EventArgs) Handles timer_ssd_4.Tick
        Try
            If ssd_4_timer_count < ssd_4_timer_delay Then
                ssd_4_timer_count = ssd_4_timer_count + 1
            End If
            label_timer_progress_4.Text = Math.Round((ssd_4_timer_count / 60), 1) & "Min / " & (ssd_4_timer_delay / 60) & "Min (" & Math.Round((ssd_4_timer_count / ssd_4_timer_delay) * 100, 0) & "%) | Time left: " & Math.Round((ssd_4_timer_delay - ssd_4_timer_count) / 60, 1) & "Min"
            Dim progressbar_width As Double = ssd_4_timer_count * (1218 / ssd_4_timer_delay)
            If progressbar_width > 1218 Then
                progressbar_width = 1218
            End If
            progressbar_timer_4.Width = progressbar_width
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub set_ssd_4_timer_delay_ValueChanged(sender As Object, e As EventArgs) Handles set_ssd_4_timer_delay.ValueChanged
        ssd_4_timer_delay = set_ssd_4_timer_delay.Value * 60
    End Sub
    '[SSD - 4]--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    '[SSD - 5]---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_ssd_5_timer_ctl_Click(sender As Object, e As EventArgs) Handles button_ssd_5_timer_ctl.Click
        If timer_ssd_5.Enabled Then
            timer_ssd_5.Stop()
            button_ssd_5_timer_ctl.Text = "Start"
            button_ssd_5_timer_ctl.ForeColor = Color.Red
        Else
            timer_ssd_5.Start()
            button_ssd_5_timer_ctl.Text = "Stop"
            button_ssd_5_timer_ctl.ForeColor = Color.Green
        End If
    End Sub
    Private Sub button_set_ssd_5_Click(sender As Object, e As EventArgs) Handles button_set_ssd_5.Click
        ssd_5_plot_threads = set_ssd_5_threads_plots.Value
        ssd_5_plot_memory = set_ssd_5_memory_plots.Value
        ssd_5_plot_type = set_ssd_5_type_plots.Value
        ssd_5_plot_ssd = set_ssd_5_ssd_plots.Text
        ssd_5_plot_hdd = set_ssd_5_hdd_plots.Text
        ssd_5_max_concurrent_plots = set_ssd_5_concurent_plots.Value
        ssd_5_plots_to_do = set_ssd_5_plots_to_do.Value
        ssd_5_timer_delay = set_ssd_5_timer_delay.Value * 60
        label_ssd_5_status.Text = "Plots done: " & ssd_5_plots_done & "/" & ssd_5_plots_to_do & vbNewLine
        label_ssd_5_status.Text += "Plots running: " & ssd_5_plots_running & "/" & ssd_5_max_concurrent_plots & vbNewLine
        label_ssd_5_status.Text += "Plots started: " & ssd_5_plots_started & "/" & ssd_5_plots_to_do
        MessageBox.Show("INFO SET: " & "Concurrent-plots:" & ssd_5_max_concurrent_plots & " Threads:" & ssd_5_plot_threads & " Memory:" & ssd_5_plot_memory & " Type:" & ssd_5_plot_type & " SSD: " & ssd_5_plot_ssd & " HHD: " & ssd_5_plot_hdd, "SSD-5 Info")
    End Sub
    Private Sub button_ssd_5_reset_Click(sender As Object, e As EventArgs) Handles button_ssd_5_reset.Click
        ssd_5_plots_done = 0
        ssd_5_timer_count = 0
        ssd_5_plots_started = 0
        ssd_5_first_plot = True
        label_ssd_5_status.Text = "Plots done: " & ssd_5_plots_done & "/" & ssd_5_plots_to_do & vbNewLine
        label_ssd_5_status.Text += "Plots running: " & ssd_5_plots_running & "/" & ssd_5_max_concurrent_plots & vbNewLine
        label_ssd_5_status.Text += "Plots started: " & ssd_5_plots_started & "/" & ssd_5_plots_to_do
        label_timer_progress_5.Text = Math.Round((ssd_5_timer_count / 60), 5) & "Min / " & ssd_5_timer_delay & "Min | Time left: " & Math.Round((ssd_5_timer_delay - (ssd_5_timer_count / 60)), 5) & "Min"
        progressbar_timer_5.Width = ssd_5_timer_count
    End Sub
    Private Sub button_set_ssd_5_color_Click(sender As Object, e As EventArgs) Handles button_set_ssd_5_color.Click
        Try
            Dim colorbox As String = set_ssd_5_color.Text
            colorbox.Replace(" ", "")
            Dim colors As String() = colorbox.Split(New Char() {","})
            Dim color_r As Integer = colors(0)
            Dim color_g As Integer = colors(1)
            Dim color_b As Integer = colors(2)
            ssd_5_color = Color.FromArgb(color_r, color_g, color_b)
            groupbox_ssd_5.ForeColor = ssd_5_color
            progressbar_timer_5.BackColor = ssd_5_color
            groupbox_ssd_color(set_ssd_5_threads_plots, set_ssd_5_memory_plots, set_ssd_5_type_plots, set_ssd_5_ssd_plots, set_ssd_5_hdd_plots, button_set_ssd_5, set_ssd_5_concurent_plots, set_ssd_5_plots_to_do, set_ssd_5_timer_delay, button_ssd_5_reset, label_ssd_5_status, set_ssd_5_color, button_set_ssd_5_color, ssd_5_color)
            groupbox_ssd_color_label(label_ssd_5_threads, label_ssd_5_memory, label_ssd_5_type, label_ssd_5_ssd, label_ssd_5_hdd, label_ssd_5_max_concurrent_plots, label_ssd_5_plots_to_do, label_ssd_5_timer_delay, label_ssd_5_color, ssd_5_color)
        Catch ex As Exception
            MessageBox.Show("Failed to apply colors" & ex.ToString(), "SSD-5")
        End Try
    End Sub
    Private Sub timer_ssd_5_Tick(sender As Object, e As EventArgs) Handles timer_ssd_5.Tick
        Try
            If ssd_5_timer_count < ssd_5_timer_delay Then
                ssd_5_timer_count = ssd_5_timer_count + 1
            End If
            label_timer_progress_5.Text = Math.Round((ssd_5_timer_count / 60), 1) & "Min / " & (ssd_5_timer_delay / 60) & "Min (" & Math.Round((ssd_5_timer_count / ssd_5_timer_delay) * 100, 0) & "%) | Time left: " & Math.Round((ssd_5_timer_delay - ssd_5_timer_count) / 60, 1) & "Min"
            Dim progressbar_width As Double = ssd_5_timer_count * (1218 / ssd_5_timer_delay)
            If progressbar_width > 1218 Then
                progressbar_width = 1218
            End If
            progressbar_timer_5.Width = progressbar_width
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub set_ssd_5_timer_delay_ValueChanged(sender As Object, e As EventArgs) Handles set_ssd_5_timer_delay.ValueChanged
        ssd_5_timer_delay = set_ssd_5_timer_delay.Value * 60
    End Sub
    '[SSD - 5]--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 

    '[COLOR PICKER FUNCTIONS]------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Function groupbox_ssd_color(set_ssd_threads_plots As NumericUpDown, set_ssd_memory_plots As NumericUpDown, set_ssd_type_plots As NumericUpDown, set_ssd_ssd_plots As TextBox, set_ssd_hdd_plots As TextBox, button_set_ssd As Button, set_ssd_concurent_plots As NumericUpDown, set_ssd_plots_to_do As NumericUpDown, set_ssd_timer_delay As NumericUpDown, button_ssd_reset As Button, label_ssd_status As Label, set_ssd_color As TextBox, button_set_ssd_color As Button, color As Color)
        set_ssd_threads_plots.ForeColor = color
        set_ssd_memory_plots.ForeColor = color
        set_ssd_type_plots.ForeColor = color
        set_ssd_ssd_plots.ForeColor = color
        set_ssd_hdd_plots.ForeColor = color
        button_set_ssd.ForeColor = color
        set_ssd_concurent_plots.ForeColor = color
        set_ssd_plots_to_do.ForeColor = color
        set_ssd_timer_delay.ForeColor = color
        button_ssd_reset.ForeColor = color
        label_ssd_status.ForeColor = color
        set_ssd_color.ForeColor = color
        button_set_ssd_color.ForeColor = color
        Return True
    End Function
    Function groupbox_ssd_color_label(label_ssd_threads As Label, label_ssd_memory As Label, label_ssd_type As Label, label_ssd_ssd As Label, label_ssd_hdd As Label, label_ssd_max_concurrent_plots As Label, label_ssd_plots_to_do As Label, label_ssd_timer_delay As Label, label_ssd_color As Label, color As Color)
        label_ssd_threads.ForeColor = color
        label_ssd_memory.ForeColor = color
        label_ssd_type.ForeColor = color
        label_ssd_ssd.ForeColor = color
        label_ssd_hdd.ForeColor = color
        label_ssd_max_concurrent_plots.ForeColor = color
        label_ssd_plots_to_do.ForeColor = color
        label_ssd_timer_delay.ForeColor = color
        label_ssd_color.ForeColor = color
        Return True
    End Function
    '[COLOR PICKER FUNCTIONS]------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    '[SSD info control]------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_plot_12_log_Click(sender As Object, e As EventArgs) Handles button_plot_12_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_12_process_logname & ".log") Then
            Process.Start(log_folder & plot_12_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_12_stop_Click(sender As Object, e As EventArgs) Handles button_plot_12_stop.Click
        Try
            plot_12_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_11_log_Click(sender As Object, e As EventArgs) Handles button_plot_11_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_11_process_logname & ".log") Then
            Process.Start(log_folder & plot_11_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_11_stop_Click(sender As Object, e As EventArgs) Handles button_plot_11_stop.Click
        Try
            plot_11_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_10_log_Click(sender As Object, e As EventArgs) Handles button_plot_10_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_10_process_logname & ".log") Then
            Process.Start(log_folder & plot_10_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_10_stop_Click(sender As Object, e As EventArgs) Handles button_plot_10_stop.Click
        Try
            plot_10_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_9_log_Click(sender As Object, e As EventArgs) Handles button_plot_9_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_9_process_logname & ".log") Then
            Process.Start(log_folder & plot_9_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_9_stop_Click(sender As Object, e As EventArgs) Handles button_plot_9_stop.Click
        Try
            plot_9_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_8_log_Click(sender As Object, e As EventArgs) Handles button_plot_8_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_8_process_logname & ".log") Then
            Process.Start(log_folder & plot_8_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_8_stop_Click(sender As Object, e As EventArgs) Handles button_plot_8_stop.Click
        Try
            plot_8_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_7_log_Click(sender As Object, e As EventArgs) Handles button_plot_7_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_7_process_logname & ".log") Then
            Process.Start(log_folder & plot_7_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_7_stop_Click(sender As Object, e As EventArgs) Handles button_plot_7_stop.Click
        Try
            plot_7_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_6_log_Click(sender As Object, e As EventArgs) Handles button_plot_6_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_6_process_logname & ".log") Then
            Process.Start(log_folder & plot_6_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_6_stop_Click(sender As Object, e As EventArgs) Handles button_plot_6_stop.Click
        Try
            plot_6_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_5_log_Click(sender As Object, e As EventArgs) Handles button_plot_5_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_5_process_logname & ".log") Then
            Process.Start(log_folder & plot_5_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_5_stop_Click(sender As Object, e As EventArgs) Handles button_plot_5_stop.Click
        Try
            plot_5_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_4_log_Click(sender As Object, e As EventArgs) Handles button_plot_4_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_4_process_logname & ".log") Then
            Process.Start(log_folder & plot_4_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_4_stop_Click(sender As Object, e As EventArgs) Handles button_plot_4_stop.Click
        Try
            plot_4_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_3_log_Click(sender As Object, e As EventArgs) Handles button_plot_3_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_3_process_logname & ".log") Then
            Process.Start(log_folder & plot_3_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_3_stop_Click(sender As Object, e As EventArgs) Handles button_plot_3_stop.Click
        Try
            plot_3_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_2_log_Click(sender As Object, e As EventArgs) Handles button_plot_2_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_2_process_logname & ".log") Then
            Process.Start(log_folder & plot_2_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_2_stop_Click(sender As Object, e As EventArgs) Handles button_plot_2_stop.Click
        Try
            plot_2_process.Kill()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button_plot_1_log_Click(sender As Object, e As EventArgs) Handles button_plot_1_log.Click
        If My.Computer.FileSystem.FileExists(log_folder & plot_1_process_logname & ".log") Then
            Process.Start(log_folder & plot_1_process_logname & ".log")
        End If
    End Sub

    Private Sub button_plot_1_stop_Click(sender As Object, e As EventArgs) Handles button_plot_1_stop.Click
        Try
            plot_1_process.Kill()
        Catch ex As Exception
        End Try
    End Sub
    '[SSD info control]------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub button_ssd_reload_Click(sender As Object, e As EventArgs) Handles button_ssd_reload.Click
        read_settings_config()
    End Sub
    Private Sub button_ssd_timer_ctl_Click(sender As Object, e As EventArgs) Handles button_ssd_timer_ctl.Click
        If timer_ssd_drives_update.Enabled Then
            timer_ssd_drives_update.Stop()
            button_ssd_timer_ctl.Text = "Start"
            button_ssd_timer_ctl.ForeColor = Color.Red
        Else
            timer_ssd_drives_update.Start()
            button_ssd_timer_ctl.Text = "Stop"
            button_ssd_timer_ctl.ForeColor = Color.Green
        End If
    End Sub
    Private Sub timer_ssd_drives_update_Tick(sender As Object, e As EventArgs) Handles timer_ssd_drives_update.Tick
        Dim Thread As New System.Threading.Thread(AddressOf ssd_drives_update)
        Thread.Start()
    End Sub
    Private Sub ssd_drives_update()
        update_drive_info(gauge_ssd_1, label_ssd_1, ssd_1_letter, ssd_1_name, " [SSD-1]")
        update_drive_info(gauge_ssd_2, label_ssd_2, ssd_2_letter, ssd_2_name, " [SSD-2]")
        update_drive_info(gauge_ssd_3, label_ssd_3, ssd_3_letter, ssd_3_name, " [SSD-3]")
        update_drive_info(gauge_ssd_4, label_ssd_4, ssd_4_letter, ssd_4_name, " [SSD-4]")
        update_drive_info(gauge_ssd_5, label_ssd_5, ssd_5_letter, ssd_5_name, " [SSD-5]")
    End Sub
    Function update_drive_info(gauge As Bunifu.Framework.UI.BunifuGauge, label As Label, drive_letter As String, drive_name As String, ssdnumber As String)

        Try

            If drive_letter = "" Or drive_name = "" Then
                label.Invoke(Sub()
                                 label.Text = "Not detected"
                             End Sub)

                gauge.Invoke(Sub()
                                 gauge.Value = 0
                             End Sub)
            Else
                Dim drive_info As New System.IO.DriveInfo(drive_letter)
                Dim total_free_space As Double = drive_info.TotalFreeSpace.ToString() / 1024 / 1024 / 1024
                Dim total_size As Double = drive_info.TotalSize.ToString() / 1024 / 1024 / 1024

                label.Invoke(Sub()
                                 label.Text = drive_name & ssdnumber & vbNewLine & Math.Round(((total_size - total_free_space) / total_size) * 100, 2) & "%" & vbNewLine & Math.Round(total_size - total_free_space, 2) & "GB / " & Math.Round(total_size, 2) & "GB" & vbNewLine & "Free: " & Math.Round(total_free_space, 2) & " GB" & vbNewLine & "Used: " & Math.Round(total_size - total_free_space, 2) & " GB"
                             End Sub)


                gauge.Invoke(Sub()
                                 gauge.Value = Math.Round(((total_size - total_free_space) / total_size) * 100, 2)
                             End Sub)
            End If

        Catch ex As Exception

            label.Invoke(Sub()
                             label.Text = "Not detected"
                         End Sub)

            gauge.Invoke(Sub()
                             gauge.Value = 0
                         End Sub)

        End Try

        Return True
    End Function


    '[Timer starter timer]------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_timer_satrter_ctl_Click(sender As Object, e As EventArgs) Handles button_timer_satrter_ctl.Click
        If timer_timer_starter.Enabled Then
            timer_timer_starter.Stop()
            button_timer_satrter_ctl.Text = "Start"
            button_timer_satrter_ctl.ForeColor = Color.Red
        Else
            timer_timer_starter.Start()
            button_timer_satrter_ctl.Text = "Stop"
            button_timer_satrter_ctl.ForeColor = Color.Green
            If ssd_1_timer_delay > 0 Then
                If timer_ssd_1.Enabled Then
                Else
                    timer_ssd_1.Start()
                    button_ssd_1_timer_ctl.Text = "Stop"
                    button_ssd_1_timer_ctl.ForeColor = Color.Green
                End If
            End If
        End If
    End Sub
    Private Sub button_timer_satrter_reset_Click(sender As Object, e As EventArgs) Handles button_timer_satrter_reset.Click
        timer_timer_starter.Stop()
        button_timer_satrter_ctl.Text = "Start"
        button_timer_satrter_ctl.ForeColor = Color.Red
        timer_timer_start_count = 0
        label_timer_starter_info.Text = Math.Round((timer_timer_start_count / 60), 1) & "Min / " & (timer_timer_start_delay / 60) & "Min (" & Math.Round((timer_timer_start_count / timer_timer_start_delay) * 100, 0) & "%) | Time left: " & Math.Round((timer_timer_start_delay - timer_timer_start_count) / 60, 1) & "Min"
    End Sub
    Private Sub num_timer_starter_time_ValueChanged(sender As Object, e As EventArgs) Handles num_timer_starter_time.ValueChanged
        timer_timer_start_delay = num_timer_starter_time.Value * 60
    End Sub
    Private Sub timer_timer_starter_Tick(sender As Object, e As EventArgs) Handles timer_timer_starter.Tick
        Try
            If timer_timer_start_count < timer_timer_start_delay Then
                timer_timer_start_count = timer_timer_start_count + 1
            End If
            label_timer_starter_info.Text = Math.Round((timer_timer_start_count / 60), 1) & "Min / " & (timer_timer_start_delay / 60) & "Min (" & Math.Round((timer_timer_start_count / timer_timer_start_delay) * 100, 0) & "%) | Time left: " & Math.Round((timer_timer_start_delay - timer_timer_start_count) / 60, 1) & "Min"
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

        If timer_timer_start_count = timer_timer_start_delay Then
            If timer_ssd_1.Enabled Then
                If timer_ssd_2.Enabled Then
                    If timer_ssd_3.Enabled Then
                        If timer_ssd_4.Enabled Then
                            If timer_ssd_5.Enabled Then
                                timer_timer_starter.Stop()
                                button_timer_satrter_ctl.Text = "Start"
                                button_timer_satrter_ctl.ForeColor = Color.Red
                                timer_timer_start_count = 0
                            Else
                                If ssd_5_timer_delay > 0 Then
                                    timer_ssd_5.Start()
                                    button_ssd_5_timer_ctl.Text = "Stop"
                                    button_ssd_5_timer_ctl.ForeColor = Color.Green
                                    timer_timer_start_count = 0
                                End If
                            End If
                        Else
                            If ssd_4_timer_delay > 0 Then
                                timer_ssd_4.Start()
                                button_ssd_4_timer_ctl.Text = "Stop"
                                button_ssd_4_timer_ctl.ForeColor = Color.Green
                                timer_timer_start_count = 0
                            End If
                        End If
                    Else
                        If ssd_3_timer_delay > 0 Then
                            timer_ssd_3.Start()
                            button_ssd_3_timer_ctl.Text = "Stop"
                            button_ssd_3_timer_ctl.ForeColor = Color.Green
                            timer_timer_start_count = 0
                        End If
                    End If
                Else
                    If ssd_2_timer_delay > 0 Then
                        timer_ssd_2.Start()
                        button_ssd_2_timer_ctl.Text = "Stop"
                        button_ssd_2_timer_ctl.ForeColor = Color.Green
                        timer_timer_start_count = 0
                    End If
                End If
            Else
                If ssd_1_timer_delay > 0 Then
                    timer_ssd_1.Start()
                    button_ssd_1_timer_ctl.Text = "Stop"
                    button_ssd_1_timer_ctl.ForeColor = Color.Green
                    timer_timer_start_count = 0
                End If
            End If
        End If
    End Sub
    '[Timer starter timer]------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Private Sub button_exit_Click(sender As Object, e As EventArgs) Handles button_exit.Click
        Me.Close()
    End Sub
End Class
